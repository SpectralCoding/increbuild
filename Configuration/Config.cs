/// <copyright file="Config.cs" company="SpectralCoding.com">
///     Copyright (c) 2015 SpectralCoding
/// </copyright>
/// <license>
/// This file is part of IncreBuild.
///
/// IncreBuild is free software: you can redistribute it and/or modify
/// it under the terms of the GNU General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
/// (at your option) any later version.
///
/// IncreBuild is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
///
/// You should have received a copy of the GNU General Public License
/// along with IncreBuild.  If not, see <http://www.gnu.org/licenses/>.
/// </license>
/// <author>Caesar Kabalan</author>

namespace IncreBuild.Configuration {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Text;
	using System.Threading.Tasks;
	using System.Xml;
	using System.Xml.Serialization;
	using IncreBuild.Support;

	[DataContract]
	public sealed class Config {
		private Dictionary<String, BuildConfiguration> m_buildConfigs = new Dictionary<String, BuildConfiguration>();
		private Boolean m_configured = false;

		private Config() {
		}

		public static Config Instance {
			get { return Nested.Instance; }
			set { Nested.Instance = value; }
		}

		[DataMember]
		public Dictionary<String, BuildConfiguration> BuildConfigs {
			get { return this.m_buildConfigs; }
		}
		[DataMember]
		public Boolean Configured {
			get { return this.m_configured; }
			set { this.m_configured = value; }
		}

		/// <summary>
		/// Saves configuration to a configuration file.
		/// </summary>
		/// <param name="filename">Filename to save Configuration as</param>
		public void Save(String filename) {
			DataContractSerializer serializer = new DataContractSerializer(typeof(Config));
			using (XmlWriter configXmlW = XmlWriter.Create(filename, new XmlWriterSettings { Indent = true })) {
				serializer.WriteObject(configXmlW, this);
				configXmlW.Close();
			}
			Console.WriteLine("Configuration exported: " + filename);
		}

		/// <summary>
		/// Loads configuration from the configuration file.
		/// </summary>
		/// <param name="filename">The absolute or relative path of the configuration xml file.</param>
		/// <returns>A Config object which contains configuration information.</returns>
		internal static Config Load(String filename) {
			if (File.Exists(filename)) {
				DataContractSerializer configDcs = new DataContractSerializer(typeof(Config));
				using (StringReader configSR = new StringReader(File.ReadAllText(filename))) {
					using (XmlReader configXmlR = XmlReader.Create(configSR)) {
						return (Config)configDcs.ReadObject(configXmlR);
					}
				}
			} else {
				Console.WriteLine("Configuration file nonexistant, loading default configuration.");
				Config configDefault = new Config();
				BuildConfiguration tempDebugBC = new BuildConfiguration();
				tempDebugBC.BuildActions.Add(VersionComponent.Major, new BuildAction(ActionMode.Manual));
				tempDebugBC.BuildActions.Add(VersionComponent.Minor, new BuildAction(ActionMode.Manual));
				tempDebugBC.BuildActions.Add(VersionComponent.Build, new BuildAction(ActionMode.Increase, 1));
				tempDebugBC.BuildActions.Add(VersionComponent.Revision, new BuildAction(ActionMode.TimeBased));
				configDefault.BuildConfigs.Add("Debug", tempDebugBC);
				BuildConfiguration tempReleaseBC = new BuildConfiguration();
				tempReleaseBC.BuildActions.Add(VersionComponent.Major, new BuildAction(ActionMode.Manual));
				tempReleaseBC.BuildActions.Add(VersionComponent.Minor, new BuildAction(ActionMode.Increase, 1));
				tempReleaseBC.BuildActions.Add(VersionComponent.Build, new BuildAction(ActionMode.Increase, 1));
				tempReleaseBC.BuildActions.Add(VersionComponent.Revision, new BuildAction(ActionMode.TimeBased));
				configDefault.BuildConfigs.Add("Release", tempReleaseBC);
				return configDefault;
			}
		}

		private class Nested {
			private static Config s_instance = Config.Load(@"IncreBuild.xml");

			internal static Config Instance {
				get { return s_instance; }
				set { s_instance = value; }
			}
		}
	}
}

/// <copyright file="ConfigViewModel.cs" company="SpectralCoding.com">
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

namespace IncreBuild.ViewModels {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization;
	using System.Xml;
	using DrWPF.Windows.Data;
	using IncreBuild.Configuration;
	using IncreBuild.Interface.Support;
	using IncreBuild.Support;

	[DataContract]
	public sealed class ConfigViewModel : ViewModelBase {
		private ObservableDictionary<String, BuildConfigurationViewModel> m_buildConfigurationViewModels;
		private Config m_config;

		private ConfigViewModel() {
			this.m_config = new Config();
			this.m_buildConfigurationViewModels = new ObservableDictionary<string, BuildConfigurationViewModel>();
		}

		public static ConfigViewModel Instance {
			get { return Nested.Instance; }
			set { Nested.Instance = value; }
		}

		[DataMember]
		public ObservableDictionary<String, BuildConfigurationViewModel> BuildConfigVMs {
			get {
				return this.m_buildConfigurationViewModels ??
					(this.m_buildConfigurationViewModels = new ObservableDictionary<string, BuildConfigurationViewModel>());
			}

			set {
				this.m_buildConfigurationViewModels = value;
				this.OnPropertyChanged("BuildConfigVMs");
			}
		}

		[DataMember]
		public Boolean Configured {
			get {
				return this.m_config.Configured;
			}

			set {
				if (this.m_config == null) {
					this.m_config = new Config();
				}
				this.m_config.Configured = value;
				this.OnPropertyChanged("Configured");
			}
		}

		public void BuildConfigVMsChanged() {
			this.OnPropertyChanged("BuildConfigVMs");
		}

		/// <summary>
		/// Saves configuration to a configuration file.
		/// </summary>
		/// <param name="filename">Filename to save Configuration as</param>
		public void Save(String filename) {
			DataContractSerializer serializer = new DataContractSerializer(typeof(ConfigViewModel));
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
		internal static ConfigViewModel Load(String filename) {
			if (File.Exists(filename)) {
				DataContractSerializer configDcs = new DataContractSerializer(typeof(ConfigViewModel));
				using (StringReader configSR = new StringReader(File.ReadAllText(filename))) {
					using (XmlReader configXmlR = XmlReader.Create(configSR)) {
						return (ConfigViewModel)configDcs.ReadObject(configXmlR);
					}
				}
			} else {
				Console.WriteLine("Configuration file nonexistant, loading default configuration.");
				return DefaultContents();
			}
		}

		internal static ConfigViewModel DefaultContents() {
			ConfigViewModel defaultCVM = new ConfigViewModel();
			BuildConfigurationViewModel tempDebugBCVM = new BuildConfigurationViewModel();
			tempDebugBCVM.BuildActionVMs.Add(
				VersionComponent.Major,
				new BuildActionViewModel(VersionComponent.Major, ActionMode.Manual));
			tempDebugBCVM.BuildActionVMs.Add(
				VersionComponent.Minor,
				new BuildActionViewModel(VersionComponent.Minor, ActionMode.Manual));
			tempDebugBCVM.BuildActionVMs.Add(
				VersionComponent.Build,
				new BuildActionViewModel(VersionComponent.Build, ActionMode.Increase, 1));
			tempDebugBCVM.BuildActionVMs.Add(
				VersionComponent.Revision,
				new BuildActionViewModel(VersionComponent.Revision, ActionMode.Calculated));
			tempDebugBCVM.UpdateAsmVer = false;
			tempDebugBCVM.UpdateAsmFileVer = true;
			tempDebugBCVM.UpdateAsmInfoVer = true;
			defaultCVM.BuildConfigVMs.Add("Debug", tempDebugBCVM);
			BuildConfigurationViewModel tempReleaseBCVM = new BuildConfigurationViewModel();
			tempReleaseBCVM.BuildActionVMs.Add(
				VersionComponent.Major,
				new BuildActionViewModel(VersionComponent.Major, ActionMode.Manual));
			tempReleaseBCVM.BuildActionVMs.Add(
				VersionComponent.Minor,
				new BuildActionViewModel(VersionComponent.Minor, ActionMode.Increase, 1));
			tempReleaseBCVM.BuildActionVMs.Add(
				VersionComponent.Build,
				new BuildActionViewModel(VersionComponent.Build, ActionMode.Increase, 1));
			tempReleaseBCVM.BuildActionVMs.Add(
				VersionComponent.Revision,
				new BuildActionViewModel(VersionComponent.Revision, ActionMode.Calculated));
			tempReleaseBCVM.UpdateAsmVer = true;
			tempReleaseBCVM.UpdateAsmFileVer = true;
			tempReleaseBCVM.UpdateAsmInfoVer = true;
			defaultCVM.BuildConfigVMs.Add("Release", tempReleaseBCVM);
			return defaultCVM;
		}

		private class Nested {
			private static ConfigViewModel s_instance = ConfigViewModel.Load(@"IncreBuild.xml");

			internal static ConfigViewModel Instance {
				get { return s_instance; }
				set { s_instance = value; }
			}
		}
	}
}

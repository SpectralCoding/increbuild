/// <copyright file="BuildActionViewModel.cs" company="SpectralCoding.com">
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
	using System.Runtime.Serialization;
	using IncreBuild.Configuration;
	using IncreBuild.Support;

	[DataContract]
	public class BuildActionViewModel : ViewModelBase {
		private BuildAction m_buildAction;
		private VersionComponent m_versionType;

		public BuildActionViewModel(VersionComponent versionComponent, ActionMode actionMode) {
			this.m_buildAction = new BuildAction();
			this.Mode = actionMode;
			this.VersionType = versionComponent;
		}

		public BuildActionViewModel(VersionComponent versionComponent, ActionMode actionMode, Int32 actionDelta)
			: this(versionComponent, actionMode) {
			this.Delta = actionDelta;
		}

		[DataMember]
		public Int32 Delta {
			get {
				return this.m_buildAction.Delta;
			}

			set {
				if (this.m_buildAction == null) {
					this.m_buildAction = new BuildAction();
				}
				this.m_buildAction.Delta = value;
				this.OnPropertyChanged("Delta");
			}
		}

		public String Description {
			get {
				// Maybe we'll use this later for a text-based description for clarity.
				switch (this.Mode) {
					case ActionMode.Decrease: return String.Format("Subtract {0}", this.Delta);
					case ActionMode.Increase: return String.Format("Add {0}", this.Delta);
					case ActionMode.Manual: return String.Format("Do Nothing", this.Delta);
					case ActionMode.Reset: return String.Format("Set to 0", this.Delta);
					case ActionMode.TimeBased: return String.Format("Set to a time-based number", this.Delta);
					default: return "Unknown Action";
				}
			}
		}
		[DataMember]
		public ActionMode Mode {
			get {
				return this.m_buildAction.Mode;
			}

			set {
				if (this.m_buildAction == null) {
					this.m_buildAction = new BuildAction();
				}
				this.m_buildAction.Mode = value;
				this.OnPropertyChanged("Mode");
			}
		}

		[DataMember]
		public VersionComponent VersionType {
			get {
				return this.m_versionType;
			}

			set {
				this.m_versionType = value;
				this.OnPropertyChanged("VersionType");
			}
		}
	}
}

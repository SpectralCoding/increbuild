/// <copyright file="BuildConfigurationViewModel.cs" company="SpectralCoding.com">
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
	using System.Runtime.Serialization;
	using DrWPF.Windows.Data;
	using IncreBuild.Interface.Support;
	using IncreBuild.Support;

	[DataContract]
	public class BuildConfigurationViewModel : ViewModelBase {
		private ObservableDictionary<VersionComponent, BuildActionViewModel> m_buildActionViewModels;
		private Boolean m_updateAsmVer;
		private Boolean m_updateAsmFileVer;
		private Boolean m_updateAsmInfoVer;

		public BuildConfigurationViewModel() {
			this.m_buildActionViewModels = new ObservableDictionary<VersionComponent, BuildActionViewModel>();
		}

		[DataMember]
		public ObservableDictionary<VersionComponent, BuildActionViewModel> BuildActionVMs {
			get {
				return this.m_buildActionViewModels ??
					(this.m_buildActionViewModels = new ObservableDictionary<VersionComponent, BuildActionViewModel>());
			}
		}

		[DataMember]
		public Boolean UpdateAsmVer {
			get {
				return this.m_updateAsmVer;
			}

			set {
				this.m_updateAsmVer = value;
				this.OnPropertyChanged("UpdateAsmVer");
			}
		}

		[DataMember]
		public Boolean UpdateAsmFileVer {
			get {
				return this.m_updateAsmFileVer;
			}

			set {
				this.m_updateAsmFileVer = value;
				this.OnPropertyChanged("UpdateAsmFileVer");
			}
		}

		[DataMember]
		public Boolean UpdateAsmInfoVer {
			get {
				return this.m_updateAsmInfoVer;
			}

			set {
				this.m_updateAsmInfoVer = value;
				this.OnPropertyChanged("UpdateAsmInfoVer");
			}
		}
	}
}

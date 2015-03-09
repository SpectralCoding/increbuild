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
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using DrWPF.Windows.Data;
	using IncreBuild.Support;

	[DataContract]
	public class BuildConfigurationViewModel : ViewModelBase {
		private ObservableDictionary<VersionComponent, BuildActionViewModel> m_buildActionViewModels;

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
	}
}

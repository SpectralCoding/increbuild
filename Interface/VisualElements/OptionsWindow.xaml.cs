/// <copyright file="OptionsWindow.xaml.cs" company="SpectralCoding.com">
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

namespace IncreBuild.Interface.VisualElements {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows;
	using System.Windows.Controls;
	using IncreBuild.Interface.Support;
	using IncreBuild.Support;
	using IncreBuild.ViewModels;

	/// <summary>
	/// Interaction logic for OptionsWindow.xaml
	/// </summary>
	public partial class OptionsWindow : Window {
		public OptionsWindow() {
			this.InitializeComponent();
			this.DataContext = ConfigViewModel.Instance;
			BuildConfigCombo.SelectedIndex = 0;
		}

		private void SaveAndCloseBtn_Click(object sender, RoutedEventArgs e) {
			ConfigViewModel.Instance.Save("IncreBuild.xml");
			Application.Current.Shutdown();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			BuildConfigCombo.SelectedIndex = 0;
		}

		private void AddBuildConfigBtn_Click(object sender, RoutedEventArgs e) {
			InputBox addInputBox = new InputBox("Add Build Configuration", "Enter the name of the new Build Configuration below:");
			addInputBox.RaiseCustomEvent += new EventHandler<InputBoxEventArgs>(this.InputBox_OK);
			addInputBox.Show();
		}

		private void InputBox_OK(object sender, InputBoxEventArgs e) {
			BuildConfigurationViewModel tempNewBC = new BuildConfigurationViewModel();
			tempNewBC.BuildActionVMs.Add(
				VersionComponent.Major,
				new BuildActionViewModel(VersionComponent.Major, ActionMode.Manual));
			tempNewBC.BuildActionVMs.Add(
				VersionComponent.Minor,
				new BuildActionViewModel(VersionComponent.Minor, ActionMode.Manual));
			tempNewBC.BuildActionVMs.Add(
				VersionComponent.Build,
				new BuildActionViewModel(VersionComponent.Build, ActionMode.Manual));
			tempNewBC.BuildActionVMs.Add(
				VersionComponent.Revision,
				new BuildActionViewModel(VersionComponent.Revision, ActionMode.Manual));
			ConfigViewModel.Instance.BuildConfigVMs.Add(e.InputText, tempNewBC);
			for (Int32 i = 0; i < BuildConfigCombo.Items.Count; i++) {
				Console.WriteLine(((KeyValuePair<String, BuildConfigurationViewModel>)BuildConfigCombo.Items[i]).Key);
				if (((KeyValuePair<String, BuildConfigurationViewModel>)BuildConfigCombo.Items[i]).Key == e.InputText) {
					BuildConfigCombo.SelectedIndex = i;
					break;
				}
			}
		}

		private void BuildConfigCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			BuildConfigurationViewModel selectedBCVM =
				ConfigViewModel.Instance.BuildConfigVMs[BuildConfigCombo.SelectedValue.ToString()];
			MajorVersion.DataContext = selectedBCVM.BuildActionVMs[VersionComponent.Major];
			MinorVersion.DataContext = selectedBCVM.BuildActionVMs[VersionComponent.Minor];
			BuildVersion.DataContext = selectedBCVM.BuildActionVMs[VersionComponent.Build];
			RevisionVersion.DataContext = selectedBCVM.BuildActionVMs[VersionComponent.Revision];
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		private void DeleteBuildConfigBtn_Click(object sender, RoutedEventArgs e) {
			String configToDelete = BuildConfigCombo.SelectedValue.ToString();
			BuildConfigCombo.SelectedIndex = 0;
			ConfigViewModel.Instance.BuildConfigVMs.Remove(configToDelete);
		}
	}
}

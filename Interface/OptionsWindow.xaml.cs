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

namespace IncreBuild.Interface {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Documents;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using System.Windows.Shapes;
	using IncreBuild.Configuration;

	/// <summary>
	/// Interaction logic for OptionsWindow.xaml
	/// </summary>
	public partial class OptionsWindow : Window {
		public OptionsWindow() {
			this.InitializeComponent();
		}

		private void SaveAndCloseBtn_Click(object sender, RoutedEventArgs e) {
			Console.WriteLine("BOO!");
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			foreach (KeyValuePair<String, BuildConfiguration> kVP in Config.Instance.BuildConfigs) {
				BuildConfigCombo.Items.Add(kVP.Key);
			}
			BuildConfigCombo.SelectedIndex = 0;
		}

		private void AddBuildConfigBtn_Click(object sender, RoutedEventArgs e) {
			InputBox AddInputBox = new InputBox();
			AddInputBox.RaiseCustomEvent += new EventHandler<InputBoxEventArgs>(InputBox_OK);
			AddInputBox.Show();
		}

		void InputBox_OK(object sender, InputBoxEventArgs e) {
			BuildConfigCombo.Items.Add(e.InputText);
		}

		private void BuildConfigCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {

		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

		}
	}
}

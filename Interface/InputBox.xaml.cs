/// <copyright file="InputBox.xaml.cs" company="SpectralCoding.com">
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
	using System.Windows;
	using IncreBuild.Support;
	using IncreBuild.ViewModels;

	/// <summary>
	/// Interaction logic for InputBox.xaml
	/// </summary>
	public partial class InputBox : Window {
		public InputBox(String title, String description) {
			this.InitializeComponent();
			this.Title = title;
			InputDescLbl.Content = description;
		}

		public event EventHandler<InputBoxEventArgs> RaiseCustomEvent;

		private void OKBtn_Click(object sender, RoutedEventArgs e) {
			InputFieldTxt.Text = InputFieldTxt.Text.Trim();
			if (InputFieldTxt.Text != String.Empty) {
				if (!ConfigViewModel.Instance.BuildConfigVMs.ContainsKey(InputFieldTxt.Text)) {
					this.RaiseCustomEvent(this, new InputBoxEventArgs(InputFieldTxt.Text));
					this.Close();
				} else {
					MessageBox.Show(
						"A Build Configuration with this name already exists.\n\nPlease pick a different name.",
						"Entry Exists",
						MessageBoxButton.OK,
						MessageBoxImage.Error,
						MessageBoxResult.OK);
				}
			} else {
				MessageBox.Show(
					"You must specify a Build Configuration name, or Cancel.",
					"Blank Entry",
					MessageBoxButton.OK,
					MessageBoxImage.Error,
					MessageBoxResult.OK);
			}
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e) {
			this.Close();
		}

		private void InputFieldTxt_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
			if (e.Key == System.Windows.Input.Key.Enter) {
				this.OKBtn_Click(null, null);
			}
		}
	}
}

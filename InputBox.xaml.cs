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

namespace IncreBuild {
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

	/// <summary>
	/// Interaction logic for InputBox.xaml
	/// </summary>
	public partial class InputBox : Window {
		public event EventHandler<InputBoxEventArgs> RaiseCustomEvent;

		public InputBox() {
			InitializeComponent();
		}

		private void OKBtn_Click(object sender, RoutedEventArgs e) {
			InputFieldTxt.Text = InputFieldTxt.Text.Trim();
			if (InputFieldTxt.Text != String.Empty) {
				if (!Config.Instance.BuildConfigs.ContainsKey(InputFieldTxt.Text)) {
					RaiseCustomEvent(this, new InputBoxEventArgs(InputFieldTxt.Text));
					this.Close();
				} else {
					MessageBox.Show("A Build Configuration with this name already exists.\n\nPlease pick a different name.", "Entry Exists", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
				}
			} else {
				MessageBox.Show("You must specify a Build Configuration name, or Cancel.", "Blank Entry", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
			}
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e) {
			this.Close();
		}
	}

	public class InputBoxEventArgs : EventArgs {
		public InputBoxEventArgs(string inputText) {
			m_inputText = inputText;
		}
		private string m_inputText;
		public string InputText {
			get { return m_inputText; }
		}
	}
}

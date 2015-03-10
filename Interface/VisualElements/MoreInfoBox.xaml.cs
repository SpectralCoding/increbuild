/// <copyright file="MoreInfoBox.xaml.cs" company="SpectralCoding.com">
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
	using System.Drawing;
	using System.Globalization;
	using System.Windows;
	using System.Windows.Markup;
	using IncreBuild.Interface.Support;
	using IncreBuild.ViewModels;

	/// <summary>
	/// Interaction logic for InputBox.xaml
	/// </summary>
	public partial class MoreInfoBox : Window {
		private String m_fullSourceLink = String.Empty;

		public MoreInfoBox(
			String windowTitle, String pageTitle, String pageContent, String sourceLink, Int32 windowWidth, Int32 windowHeight) {
			this.InitializeComponent();
			this.Width = windowWidth;
			this.Height = windowHeight;
			this.Title = windowTitle;
			this.TitleLbl.Content = pageTitle;
			this.ContentsLbl.Content = pageContent;
			this.m_fullSourceLink = sourceLink;
			using (Graphics tempGraphic = Graphics.FromImage(new Bitmap(1, 1))) {
				SizeF strSize = tempGraphic.MeasureString(
					this.m_fullSourceLink,
					new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point));
				// 64 Pixels represents the side margins of the Source "link" label.
				if (strSize.Width > this.Width - 64) {
					for (Int32 i = this.m_fullSourceLink.Length; i > 0; i--) {
						strSize = tempGraphic.MeasureString(
							this.m_fullSourceLink.Substring(0, i) + "...",
							new Font("Segoe UI", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point));
						if (strSize.Width <= (this.Width - 64)) {
							this.SourceLbl.Tag = sourceLink.Substring(0, i) + "...";
							Console.WriteLine(this.SourceLbl.Tag);
							break;
						}
					}
				} else {
					this.SourceLbl.Tag = sourceLink;
				}
			}
		}

		private void SourceLbl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
			System.Diagnostics.Process.Start(this.m_fullSourceLink);
		}
	}
}

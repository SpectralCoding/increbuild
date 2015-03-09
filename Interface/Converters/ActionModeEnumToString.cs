/// <copyright file="ActionModeEnumToString.cs" company="SpectralCoding.com">
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

namespace IncreBuild.Interface.Converters {
	using System;
	using System.Globalization;
	using System.Windows.Data;
	using IncreBuild.Support;

	[ValueConversion(typeof(ActionMode), typeof(String))]
	public class ActionModeEnumToString : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			ActionMode actionModeEnum = (ActionMode)value;
			switch (actionModeEnum) {
				case ActionMode.Decrease: return "Decrease";
				case ActionMode.Increase: return "Increase";
				case ActionMode.Manual: return "Do Nothing";
				case ActionMode.Reset: return "Reset";
				case ActionMode.Calculated: return "Calculate";
				default: return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			string actionModeStr = (string)value;
			switch (actionModeStr) {
				case "Decrease": return ActionMode.Decrease;
				case "Increase": return ActionMode.Increase;
				case "Do Nothing": return ActionMode.Manual;
				case "Reset": return ActionMode.Reset;
				case "Calculate": return ActionMode.Calculated;
				default: return null;
			}
		}
	}
}

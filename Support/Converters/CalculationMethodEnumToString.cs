/// <copyright file="CalculationMethodEnumToString.cs" company="SpectralCoding.com">
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

namespace IncreBuild.Support.Converters {
	using System;
	using System.Globalization;
	using System.Windows.Data;

	[ValueConversion(typeof(VersionComponent), typeof(String))]
	public class CalculationMethodEnumToString : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			CalculationMethod calcMethodEnum = (CalculationMethod)value;
			switch (calcMethodEnum) {
				case CalculationMethod.DaysSinceEpoch: return "Epoch";
				default: return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			// We really shouldn't even need this because it only ends up in an unchangable label.
			string calcMethodString = (string)value;
			switch (calcMethodString) {
				case "Epoch": return CalculationMethod.DaysSinceEpoch;
				default: return null;
			}
		}
	}
}

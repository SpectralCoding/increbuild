/// <copyright file="Enumerations.cs" company="SpectralCoding.com">
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
	/// <summary>
	/// Contains type definitions for command line arguments.
	/// </summary>
	public enum ArgumentType {
		/// <summary>
		/// Corresponds to the "/releasetype" option.
		/// </summary>
		ReleaseType,

		/// <summary>
		/// Corresponds to the "/projectdir" option.
		/// </summary>
		ProjectDir,

		/// <summary>
		/// Corresponds to the "/options" option.
		/// </summary>
		Options,

		/// <summary>
		/// Corresponds to the "/loadconfig" option.
		/// </summary>
		LoadConfig
	}

	public enum VersionComponent {
		/// <summary>
		/// Corresponds to the first number in a version string: X.0.0.0
		/// </summary>
		Major,

		/// <summary>
		/// Corresponds to the second number in a version string: 0.X.0.0
		/// </summary>
		Minor,

		/// <summary>
		/// Corresponds to the third number in a version string: 0.0.X.0
		/// </summary>
		Build,

		/// <summary>
		/// Corresponds to the fourth number in a version string: 0.0.0.X
		/// </summary>
		Revision
	}

	public enum ActionMode {
		/// <summary>
		/// Add a number to the version.
		/// </summary>
		Increase,

		/// <summary>
		/// Subtract a number from the version.
		/// </summary>
		Decrease,

		/// <summary>
		/// Change the version value to zero.
		/// </summary>
		Reset,

		/// <summary>
		/// Calculate a version value based on the current time.
		/// </summary>
		TimeBased,

		/// <summary>
		/// Do not change a version value.
		/// </summary>
		Manual
	}
}

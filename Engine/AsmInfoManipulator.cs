/// <copyright file="AsmInfoManipulator.cs" company="SpectralCoding.com">
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

namespace IncreBuild.Engine {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using IncreBuild.ViewModels;
	using IncreBuild.Support;

	public class AsmInfoManipulator {
		private List<String> m_asmInfoContents = new List<String>();
		////private Dictionary<VersionComponent, >

		public AsmInfoManipulator(String asmInfoFilename) {
			this.ParseFile(asmInfoFilename);
		}

		private void ParseFile(String asmInfoFilename) {
			this.m_asmInfoContents = File.ReadAllLines(asmInfoFilename).ToList<String>();
		}
	}
}

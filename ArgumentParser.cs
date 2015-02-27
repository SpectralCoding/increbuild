// Copyright 2015 SpectralCoding
// 
// This file is part of IncreBuild.
// 
// IncreBuild is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// IncreBuild is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with IncreBuild.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreBuild {
	public static class ArgumentParser {
		/// <summary>
		/// Takes a string array and outputs a Dictionary containing option-types and the values if applicable.
		/// </summary>
		/// <param name="args">String Array, usually from Main().</param>
		/// <returns>Dictionary&lt;ArgumentType, string&gt; containing options and values.></returns>
		public static Dictionary<ArgumentType, string> ParseArguments(string[] args) {
			Dictionary<ArgumentType, string> ArgumentDict = new Dictionary<ArgumentType, string>();
			for (int i = 0; i < args.Length; i++) {
				switch (args[i].ToLower()) {
					case "/options":
						ArgumentDict.Add(ArgumentType.Options, "OPTIONS");
						break;
					case "/releasetype":
						if ((i + 1) <= args.Length) {
							ArgumentDict.Add(ArgumentType.ReleaseType, args[i+1]);
							i++;
						} else { Console.WriteLine("Invalid Number of Arguments. No type given for /type."); }
						break;
					case "/projectdir":
						if ((i + 1) <= args.Length) {
							string FixedPath = args[i + 1];
							// If there is a quote at the end, remove it.
							if (FixedPath.Substring(FixedPath.Length - 1, 1) == "\"") {
								FixedPath = FixedPath.Substring(0, FixedPath.Length - 1);
							}
							// If there isn't a slash at the end, add one.
							if (FixedPath.Substring(FixedPath.Length - 1, 1) != "\\") {
								FixedPath += "\\";
							}
							// Remove any double slashes that may have been created by
							// users trying to be too smart.
							FixedPath = FixedPath.Replace("\\\\", "\\");
							ArgumentDict.Add(ArgumentType.ProjectDir, FixedPath);
							i++;
						} else { Console.WriteLine("Invalid Number of Arguments. No path given for /projectdir."); }
						break;
					default:
						Console.WriteLine("Unknown Argument: {0}", args[i]);
						break;
				}
			}
			return ArgumentDict;
		}
	}
}

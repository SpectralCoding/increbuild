/// <copyright file="Program.cs" company="SpectralCoding.com">
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
	using System.Windows;
	using IncreBuild.Interface;
	using IncreBuild.Support;
	using IncreBuild.ViewModels;

	public class Program {
		[STAThread]
		private static void Main(String[] args) {
			Dictionary<ArgumentType, String> argList = ArgumentParser.ParseArguments(args);
			if (argList.ContainsKey(ArgumentType.LoadConfig)) {
				ConfigViewModel.Load(argList[ArgumentType.LoadConfig]);
			} else {
				ConfigViewModel.Load(@"IncreBuild.xml");
			}
			if (argList.Count == 0 || argList.ContainsKey(ArgumentType.Options)) {
				// No Arguments or the "/options" argument exists.
				// Don't run anything, display the configuration interface.
				Application optionsApp = new Application();
				optionsApp.Run(new OptionsWindow());
			} else {
				Console.WriteLine("[[ PLACEHOLDER FOR APPLICATION LOGIC ]]");
			}
			////Console.ReadLine();
		}
	}
}

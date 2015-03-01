/// <copyright file="BuildAction.cs" company="SpectralCoding.com">
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

namespace IncreBuild.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Text;
	using System.Threading.Tasks;
	using IncreBuild.Support;

	[DataContract]
	public class BuildAction {
		private Int32 m_delta;
		private ActionMode m_mode;

		public BuildAction(ActionMode actionMode) {
			this.Mode = actionMode;
		}

		public BuildAction(ActionMode actionMode, Int32 actionDelta) : this(actionMode) {
			this.Delta = actionDelta;
		}

		[DataMember]
		public Int32 Delta {
			get { return this.m_delta; }
			set { this.m_delta = value; }
		}

		public String Description {
			get {
				// Maybe we'll use this later for a text-based description for clarity.
				switch (this.m_mode) {
					case ActionMode.Decrease: return String.Format("Subtract {0}", this.Delta);
					case ActionMode.Increase: return String.Format("Add {0}", this.Delta);
					case ActionMode.Manual: return String.Format("Do Nothing", this.Delta);
					case ActionMode.Reset: return String.Format("Set to 0", this.Delta);
					case ActionMode.TimeBased: return String.Format("Set to a time-based number", this.Delta);
					default: return "Unknown Action";
				}
			}
		}
		[DataMember]
		public ActionMode Mode {
			get { return this.m_mode; }
			set { this.m_mode = value; }
		}
	}
}

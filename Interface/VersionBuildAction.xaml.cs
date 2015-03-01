using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IncreBuild.Support;

namespace IncreBuild.Interface {
	/// <summary>
	/// Interaction logic for VersionBuildAction.xaml
	/// </summary>
	public partial class VersionBuildAction : UserControl {
		public VersionBuildAction() {
			InitializeComponent();
		}

		private void VersionBuildAction_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
			Console.WriteLine("VBA DC: " + this.DataContext);
			Console.WriteLine("VBA Txt DC: " + ValueTxt.DataContext);
		}
	}

	[ValueConversion(typeof(ActionMode), typeof(String))]
	public class ActionModeEnumToString : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			ActionMode ActionModeEnum = (ActionMode)value;
			switch (ActionModeEnum) {
				case ActionMode.Decrease: return "Decrease";
				case ActionMode.Increase: return "Increase";
				case ActionMode.Manual: return "Do Nothing";
				case ActionMode.Reset: return "Reset";
				case ActionMode.TimeBased: return "Calculate";
				default: return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			string ActionModeStr = (string)value;
			switch (ActionModeStr) {
				case "Decrease": return ActionMode.Decrease;
				case "Increase": return ActionMode.Increase;
				case "Do Nothing": return ActionMode.Manual;
				case "Reset": return ActionMode.Reset;
				case "Calculate": return ActionMode.TimeBased;
				default: return null;
			}
			return null;
		}
	}


}

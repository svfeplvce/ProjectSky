using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjectSky.Core
{
    public class MoveStringToBool : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var checkBox = values[1] as CheckBox;
            var grid = checkBox.Parent as Grid;
            if (values[0] is string MoveType && MoveType == "DEFAULT")
            {
                for (var i = 1; i < grid.Children.Count - 1; i++)
                {
                    var child = grid.Children[i];
                    child.IsEnabled = false;
                }
                return true;
            }
            for (var i = 1; i < grid.Children.Count - 1; i++)
            {
                var child = grid.Children[i];
                child.IsEnabled = true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[1] { (bool)value ? "DEFAULT" : "MANUAL" };
        }
    }
}

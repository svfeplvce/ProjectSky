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
    public class CommandMultiVal : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var checkBox = values[0] as CheckBox;
            var poke = values[1] as string;
            var grid = checkBox.Parent as Grid;
            return new Tuple<CheckBox, string>(checkBox, poke);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[1];
        }
    }
}

using ProjectSky.Models;
using ProjectSky.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ProjectSky.Core
{
    public class MethodArgType : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 3 && values[0] is int methodID && values[1] is ObservableCollection<EvoMethod> evoMethods && values[2] is Dictionary<string, ObservableCollection<string>> EvoArgs)
            {
                EvoMethod selectedMethod = evoMethods.FirstOrDefault(m => m.MethodID == methodID);
                if (selectedMethod != null)
                {
                    if (EvoArgs.TryGetValue(selectedMethod.ArgType, out ObservableCollection<string> parameters))
                    {
                        return parameters;
                    }
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            try
            {
                return new object[] { null, null, null };
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                return DependencyProperty.UnsetValue as object[]; // Return a valid value or DependencyProperty.UnsetValue
            }
        }
    }
}

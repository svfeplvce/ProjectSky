using ProjectSky.Models;
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
    public class ItemToPlib : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 5 && values[0] is int param && values[1] is int methodID && values[2] is ObservableCollection<EvoMethod> evoMethods && values[3] is Dictionary<string, ObservableCollection<string>> EvoArgs && values[4] is Plib.PlibArray plib)
            {
                EvoMethod selectedMethod = evoMethods.FirstOrDefault(m => m.MethodID == methodID);
                if (selectedMethod != null)
                {
                    if (selectedMethod.ArgType == "Item")
                    {
                        var plibEntry = plib.values.FirstOrDefault(x => x.plibID == param);
                        if (plibEntry != null)
                        {
                            return plibEntry.itemID;
                        }
                        return 0;
                    }
                }
            }
            return values[0];
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

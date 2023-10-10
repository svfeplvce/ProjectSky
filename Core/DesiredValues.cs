﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectSky.Core
{
    public class DesiredValues : IValueConverter
    {
        private readonly List<int> ints = new List<int>() { 0,1,2,3,4,5,6,7,9,10,11,12,13,14,15,16,17,18,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,91,92 };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ints.Contains((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

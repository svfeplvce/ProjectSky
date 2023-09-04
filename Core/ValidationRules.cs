using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectSky.Core
{
    public class ValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !IsValid(value.ToString()))
            {
                return new ValidationResult(false, null);
            }

            return ValidationResult.ValidResult;
        }

        private bool IsValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}

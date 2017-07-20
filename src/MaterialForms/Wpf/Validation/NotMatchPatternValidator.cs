﻿using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.Validation
{
    public class NotMatchPatternValidator : ComparisonValidator
    {
        public NotMatchPatternValidator(ValidationPipe pipe, IProxy argument, IErrorStringProvider errorProvider, IBoolProxy isEnforced,
            IValueConverter valueConverter, bool strictValidation, bool validatesOnTargetUpdated)
            : base(pipe, argument, errorProvider, isEnforced, valueConverter, strictValidation, validatesOnTargetUpdated)
        {
        }

        protected override bool ValidateValue(object value, CultureInfo cultureInfo)
        {
            if (!(Argument.Value is string pattern))
            {
                return true;
            }

            if (value is string s)
            {
                return !Regex.IsMatch(s, pattern);
            }

            return true;
        }
    }
}

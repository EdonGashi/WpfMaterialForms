﻿using System;
using System.Globalization;
using System.Windows.Data;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.Validation
{
    public class LessThanValidator : ComparisonValidator
    {
        public LessThanValidator(ValidationPipe pipe, IProxy argument, IErrorStringProvider errorProvider,
            IBoolProxy isEnforced,
            IValueConverter valueConverter, bool strictValidation, bool validatesOnTargetUpdated)
            : base(pipe, argument, errorProvider, isEnforced, valueConverter, strictValidation,
                validatesOnTargetUpdated)
        {
        }

        protected override bool ValidateValue(object value, CultureInfo cultureInfo)
        {
            var comparand = Argument.Value;
            if (comparand == null)
                return true;

            if (value == null)
                return false;

            if ( /*value != null &&*/ comparand is IConvertible && value.GetType() != comparand.GetType())
                comparand = Convert.ChangeType(comparand, value.GetType(), CultureInfo.InvariantCulture);

            if (value is IComparable c)
                return c.CompareTo(comparand) < 0;

            return false;
        }
    }
}
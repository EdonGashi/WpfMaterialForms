﻿using System.Globalization;
using System.Windows.Data;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.Validation
{
    public class NotNullValidator : FieldValidator
    {
        public NotNullValidator(ValidationPipe pipe, IErrorStringProvider errorProvider, IBoolProxy isEnforced,
            IValueConverter valueConverter, bool strictValidation, bool validatesOnTargetUpdated)
            : base(pipe, errorProvider, isEnforced, valueConverter, strictValidation, validatesOnTargetUpdated)
        {
        }

        protected override bool ValidateValue(object value, CultureInfo cultureInfo)
        {
            return value != null;
        }
    }
}

﻿using System;
using System.Globalization;
using System.Windows.Data;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.Validation
{
    public class MethodInvocationValidator : FieldValidator
    {
        private readonly Func<object, CultureInfo, bool, bool> method;

        public MethodInvocationValidator(ValidationPipe pipe, Func<object, CultureInfo, bool, bool> method,
            IErrorStringProvider errorProvider,
            IBoolProxy isEnforced, IValueConverter valueConverter, bool strictValidation, bool validatesOnTargetUpdated)
            : base(pipe, errorProvider, isEnforced, valueConverter, strictValidation, validatesOnTargetUpdated)
        {
            this.method = method;
        }

        protected override bool ValidateValue(object value, CultureInfo cultureInfo)
        {
            return method(value, cultureInfo, StrictValidation);
        }
    }
}
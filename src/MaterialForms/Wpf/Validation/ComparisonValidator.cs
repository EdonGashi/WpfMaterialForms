﻿using System;
using System.Windows.Data;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.Validation
{
    public abstract class ComparisonValidator : FieldValidator
    {
        protected ComparisonValidator(ValidationPipe pipe, IProxy argument, IErrorStringProvider errorProvider, IBoolProxy isEnforced,
            IValueConverter valueConverter, bool strictValidation, bool validatesOnTargetUpdated)
            : base(pipe, errorProvider, isEnforced, valueConverter, strictValidation, validatesOnTargetUpdated)
        {
            Argument = argument ?? throw new ArgumentNullException(nameof(argument));
        }

        public IProxy Argument { get; }
    }
}

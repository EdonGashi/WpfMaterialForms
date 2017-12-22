﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using MaterialForms.Wpf.Resources;
using MaterialForms.Wpf.Validation;

namespace MaterialForms.Wpf.Fields.Defaults
{
    public sealed class ConvertedField : DataFormField
    {
        public ConvertedField(string key, Type propertyType, ReplacementPipe replacementPipe) : base(key, propertyType)
        {
            ReplacementPipe = replacementPipe;
            CreateBinding = false;
        }

        public IValueProvider Mask { get; set; }

        public ReplacementPipe ReplacementPipe { get; }

        public Func<IResourceContext, IErrorStringProvider> ConversionErrorMessage { get; set; }

        protected internal override void Freeze()
        {
            base.Freeze();
            if (IsDirectBinding)
            {
                Resources.Add("Value",
                    new ConvertedDirectBinding(BindingOptions, Validators, ReplacementPipe,
                        ConversionErrorMessage ?? (ctx => new PlainErrorStringProvider("Invalid value."))));
            }
            else if (string.IsNullOrEmpty(Key))
            {
                Resources.Add("Value", LiteralValue.Null);
            }
            else
            {
                Resources.Add("Value",
                    new ConvertedDataBinding(Key, BindingOptions, Validators, ReplacementPipe,
                        ConversionErrorMessage ?? (ctx => new PlainErrorStringProvider("Invalid value."))));
            }

            Resources.Add(nameof(Mask), Mask ?? LiteralValue.Null);
        }

        protected internal override IBindingProvider CreateBindingProvider(IResourceContext context,
            IDictionary<string, IValueProvider> formResources)
        {
            return new ConvertedPresenter(context, Resources, formResources);
        }
    }

    public class ConvertedPresenter : ValueBindingProvider
    {
        static ConvertedPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ConvertedPresenter), new FrameworkPropertyMetadata(typeof(ConvertedPresenter)));
        }

        public ConvertedPresenter(IResourceContext context,
            IDictionary<string, IValueProvider> fieldResources,
            IDictionary<string, IValueProvider> formResources)
            : base(context, fieldResources, formResources, true)
        {
        }
    }
}

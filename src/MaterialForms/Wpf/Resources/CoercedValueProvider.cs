﻿using System.Windows.Data;

namespace MaterialForms.Wpf.Resources
{
    public class CoercedValueProvider<T> : IValueProvider
    {
        private readonly IValueProvider innerProvider;
        private readonly object defaultValue;

        public CoercedValueProvider(IValueProvider innerProvider, object defaultValue)
        {
            this.innerProvider = innerProvider;
            this.defaultValue = defaultValue;
        }

        public BindingBase ProvideBinding(IResourceContext context)
        {
            var binding = innerProvider.ProvideBinding(context);
            binding.FallbackValue = defaultValue;
            return binding;
        }

        public object ProvideValue(IResourceContext context)
        {
            var value = innerProvider.ProvideValue(context);
            if (value is BindingBase binding)
            {
                binding.FallbackValue = defaultValue;
                return binding;
            }

            if (value is T)
            {
                return value;
            }

            return defaultValue;
        }
    }
}

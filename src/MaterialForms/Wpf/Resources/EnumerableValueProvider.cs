﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace MaterialForms.Wpf.Resources
{
    public class EnumerableKeyValueProvider : IValueProvider
    {
        private readonly bool addNull;
        private readonly IEnumerable<KeyValuePair<ValueType, IValueProvider>> elements;

        public EnumerableKeyValueProvider(IEnumerable<KeyValuePair<ValueType, IValueProvider>> elements, bool addNull)
        {
            this.addNull = addNull;
            this.elements = elements ?? throw new ArgumentNullException(nameof(elements));
        }

        public BindingBase ProvideBinding(IResourceContext context)
        {
            return new Binding
            {
                Source = ProvideValue(context),
                Mode = BindingMode.OneTime
            };
        }

        public object ProvideValue(IResourceContext context)
        {
            var list = elements.Select(e =>
            {
                var proxy = e.Value.GetStringValue(context);
                proxy.Key = e.Key;
                return proxy;
            }).ToList();

            if (addNull)
                list.Insert(0, new StringProxy {Key = null, Value = ""});

            return list;
        }
    }
}
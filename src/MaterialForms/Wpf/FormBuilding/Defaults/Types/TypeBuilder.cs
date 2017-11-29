﻿using System;
using MaterialForms.Wpf.Fields;

namespace MaterialForms.Wpf.FormBuilding.Defaults.Types
{
    public abstract class TypeBuilder<T> : IFieldBuilder
    {
        public FormElement TryBuild(IFormProperty property, Func<string, object> deserializer)
        {
            if (property.PropertyType != typeof(T))
                return null;

            return Build(property, deserializer);
        }

        protected abstract FormElement Build(IFormProperty property, Func<string, object> deserializer);
    }
}
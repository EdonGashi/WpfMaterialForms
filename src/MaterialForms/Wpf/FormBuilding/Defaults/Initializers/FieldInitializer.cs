﻿using System;
using Humanizer;
using MaterialForms.Wpf.Annotations;
using MaterialForms.Wpf.Fields;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.FormBuilding.Defaults.Initializers
{
    internal class FieldInitializer : IFieldInitializer
    {
        public void Initialize(FormElement element, IFormProperty property, Func<string, object> deserializer)
        {
            var attr = property.GetCustomAttribute<FieldAttribute>();
            if (attr == null)
            {
                if (element is FormField formField && formField.Name == null)
                    formField.Name = new LiteralValue(property.Name.Humanize());

                return;
            }

            element.IsVisible = Utilities.GetResource<bool>(attr.IsVisible, true, Deserializers.Boolean);

            if (element is FormField field)
            {
                field.Name = attr.HasName
                    ? Utilities.GetStringResource(attr.Name)
                    : new LiteralValue(property.Name.Humanize());
                field.ToolTip = Utilities.GetStringResource(attr.ToolTip);
                field.Icon = Utilities.GetIconResource(attr.Icon);
            }

            if (element is DataFormField dataField)
            {
                if (property.CanWrite)
                    dataField.IsReadOnly = Utilities.GetResource<bool>(attr.IsReadOnly, false, Deserializers.Boolean);
                else
                    dataField.IsReadOnly = LiteralValue.True;

                var type = property.PropertyType;
                if (attr.DefaultValue != null)
                    dataField.DefaultValue = Utilities.GetResource<object>(attr.DefaultValue, null, deserializer);
                else if (!type.IsValueType)
                    dataField.DefaultValue = LiteralValue.Null;
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    dataField.DefaultValue = LiteralValue.Null;
            }
        }
    }
}
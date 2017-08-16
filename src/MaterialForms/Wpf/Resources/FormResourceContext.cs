﻿using System.Windows;
using System.Windows.Data;
using MaterialForms.Wpf.Controls;

namespace MaterialForms.Wpf.Resources
{
    internal class FormResourceContext : IFrameworkResourceContext
    {
        public FormResourceContext(DynamicForm form)
            : this(form, null)
        {
        }

        public FormResourceContext(DynamicForm form, string basePath)
        {
            Form = form;
            BasePath = basePath;
        }

        public DynamicForm Form { get; }

        public string BasePath { get; }

        public object GetModelInstance() => Form.Value;

        public object GetContextInstance() => Form.Context;

        public Binding CreateDirectModelBinding()
        {
            return new Binding(nameof(Form.Model) + BasePath)
            {
                Source = Form
            };
        }

        public Binding CreateModelBinding(string path)
        {
            return new Binding(nameof(Form.Value) + BasePath + Resource.FormatPath(path))
            {
                Source = Form
            };
        }

        public Binding CreateContextBinding(string path)
        {
            return new Binding(nameof(Form.Context) + BasePath + Resource.FormatPath(path))
            {
                Source = Form
            };
        }

        public object TryFindResource(object key)
        {
            return Form.TryFindResource(key);
        }

        public object FindResource(object key)
        {
            return Form.FindResource(key);
        }

        public void AddResource(object key, object value)
        {
            Form.Resources.Add(key, value);
        }

        public FrameworkElement GetOwningElement()
        {
            return Form;
        }
    }
}

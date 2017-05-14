using System;
using System.Windows;
using System.Windows.Data;

namespace MaterialForms.Wpf.Resources
{
    public class StaticResource : Resource
    {
        public StaticResource(string resourceKey)
        {
            ResourceKey = resourceKey ?? throw new ArgumentNullException(nameof(resourceKey));
        }

        public string ResourceKey { get; }

        public override bool IsDynamic => false;

        public override BindingBase GetBinding(FrameworkElement element)
        {
            return new Binding
            {
                Source = element.FindResource(ResourceKey),
                Mode = BindingMode.OneTime
            };
        }
    }
}
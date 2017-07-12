using System.Windows.Data;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.Fields
{
    /// <summary>
    /// Provides bindings by resource name.
    /// </summary>
    public interface IBindingProvider
    {
        /// <summary>
        /// Returns a <see cref="BindingProxy"/> bound to the value returned by <see cref="ProvideValue"/>.
        /// </summary>
        /// <param name="name">Resource name. This is not the object property name.</param>
        /// <returns>Returns a <see cref="BindingProxy"/>.</returns>
        BindingProxy this[string name] { get; }

        /// <summary>
        /// Resolves the value for the specified resource.
        /// The result may be a <see cref="BindingBase"/> or a literal value.
        /// </summary>
        /// <param name="name">Resource name. This is not the object property name.</param>
        /// <returns>Returns a <see cref="BindingBase"/> or a literal value.</returns>
        object ProvideValue(string name);
    }
}

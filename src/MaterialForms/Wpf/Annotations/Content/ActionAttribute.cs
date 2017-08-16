﻿using System;
using System.Runtime.CompilerServices;
using MaterialForms.Wpf.Fields;
using MaterialForms.Wpf.Fields.Defaults;
using MaterialForms.Wpf.FormBuilding;
using MaterialForms.Wpf.Resources;

namespace MaterialForms.Wpf.Annotations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class ActionAttribute : FormContentAttribute
    {
        public ActionAttribute(string name, string content, [CallerLineNumber] int position = 0)
            : base(position)
        {
            ActionName = name;
            Content = content;
            // Actions are grouped by default.
            ShareLine = true;
            // Actions are inserted after elements by default.
            InsertAfter = true;
            // Actions are displayed to the right by default.
            LinePosition = Controls.Position.Right;
        }

        public bool IsDefault { get; set; }

        public bool IsCancel { get; set; }

        /// <summary>
        /// Action identifier that is passed to handlers.
        /// </summary>
        public string ActionName { get; }

        /// <summary>
        /// Action parameter. Accepts a dynamic expression.
        /// </summary>
        public object Parameter { get; set; }

        /// <summary>
        /// Displayed content. Accepts a dynamic expression.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Determines whether this action can be performed.
        /// Accepts a boolean or a dynamic resource.
        /// </summary>
        public object IsEnabled { get; set; }

        /// <summary>
        /// Displayed icon. Accepts a PackIconKind or a dynamic resource.
        /// </summary>
        public object Icon { get; set; }

        /// <summary>
        /// Determines whether the model will be validated before the action is executed.
        /// </summary>
        public object Validates { get; set; }

        /// <summary>
        /// Determines whether this action will close dialogs that host it.
        /// </summary>
        public object ClosesDialog { get; set; }

        /// <summary>
        /// Determines whether the model will be reset to default values before the action is executed.
        /// </summary>
        public object IsReset { get; set; }

        protected override FormElement CreateElement()
        {
            return new ActionElement
            {
                ActionName = BoundExpression.ParseSimplified(ActionName),
                ActionParameter = Parameter is string expr
                    ? BoundExpression.ParseSimplified(expr)
                    : new LiteralValue(Parameter),
                Content = Utilities.GetStringResource(Content),
                Icon = Utilities.GetIconResource(Icon),
                Validates = Utilities.GetResource<bool>(Validates, false, Deserializers.Boolean),
                ClosesDialog = Utilities.GetResource<bool>(ClosesDialog, true, Deserializers.Boolean),
                IsReset = Utilities.GetResource<bool>(IsReset, false, Deserializers.Boolean),
                IsEnabled = Utilities.GetResource<bool>(IsEnabled, true, Deserializers.Boolean)
            };
        }
    }
}

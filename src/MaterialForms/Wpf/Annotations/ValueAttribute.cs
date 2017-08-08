﻿using System;

namespace MaterialForms.Wpf.Annotations
{
    /// <summary>
    /// Specifies a validation rule for a field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class ValueAttribute : Attribute
    {
        public ValueAttribute(string converter, Must condition)
            : this(converter, condition, null, false)
        {
        }

        public ValueAttribute(string converter, Must condition, object argument)
            : this(converter, condition, argument, true)
        {
        }

        public ValueAttribute(Must condition) 
            : this(null, condition, null, false)
        {
        }

        public ValueAttribute(Must condition, object argument) 
            : this(null, condition, argument, true)
        {
        }

        private ValueAttribute(string converter, Must condition, object argument, bool hasValue)
        {
            Converter = converter;
            Condition = condition;
            Argument = argument;
            HasValue = hasValue;
            ValidatesOnTargetUpdated = false;
        }

        /// <summary>
        /// Value converter name.
        /// </summary>
        public string Converter { get; }

        /// <summary>
        /// Validator type.
        /// </summary>
        public Must Condition { get; }

        /// <summary>
        /// Validator argument. Accepts an object or a dynamic expression.
        /// May be ignored or throw errors if the supplied value is not suitable for the validator.
        /// Accepts an object or a dynamic resource.
        /// </summary>
        public object Argument { get; }

        internal bool HasValue { get; }

        /// <summary>
        /// Error message if validation fails. Accepts a string or a dynamic expression.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Determines whether this validator is active. Accepts a boolean or a dynamic resource.
        /// </summary>
        public object When { get; set; }

        /// <summary>
        /// If set to true, values that don't pass validation
        /// are prevented from being written to the property.
        /// </summary>
        public bool StrictValidation { get; set; }

        /// <summary>
        /// Determines whether property changes cause validation.
        /// </summary>
        public bool ValidatesOnTargetUpdated { get; set; }

        /// <summary>
        /// Specifies what happens when argument values change.
        /// </summary>
        public ValidationAction ArgumentUpdatedAction { get; set; }
    }
}

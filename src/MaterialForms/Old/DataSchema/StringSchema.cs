﻿using System.Windows.Controls;
using MaterialForms.Controls;

namespace MaterialForms
{
    public class StringSchema : SchemaBase
    {
        private string value;
        private bool isMultiLine;
        private bool isReadOnly;

        public string Value
        {
            get { return value; }
            set
            {
                if (value == this.value) return;
                this.value = value;
                OnPropertyChanged();
            }
        }

        public bool IsMultiLine
        {
            get { return isMultiLine; }
            set
            {
                if (value == isMultiLine) return;
                isMultiLine = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(View));
            }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                if (value == isReadOnly) return;
                isReadOnly = value;
                OnPropertyChanged();
            }
        }

        public override UserControl CreateView()
        {
            if (IsMultiLine)
            {
                return new MultiLineTextControl
                {
                    DataContext = this
                };
            }

            return new SingleLineTextControl
            {
                DataContext = this
            };
        }

        public override bool HoldsValue => true;

        public override object GetValue() => Value;

        public override void SetValue(object obj)
        {
            Value = obj?.ToString();
        }

        public ValidationCallback<string> Validation { get; set; }

        protected override bool OnValidation()
        {
            var callback = Validation;
            if (callback == null)
            {
                return true;
            }

            Error = callback(value);
            return HasNoError;
        }
    }
}

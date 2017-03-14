﻿using System.Windows.Controls;
using MaterialForms.Controls;

namespace MaterialForms
{
    public class BooleanSchema : SchemaBase
    {
        private bool value;
        private bool isCheckBox;

        public bool Value
        {
            get { return value; }
            set
            {
                if (value == this.value) return;
                this.value = value;
                OnPropertyChanged();
            }
        }

        public bool IsCheckBox
        {
            get { return isCheckBox; }
            set
            {
                if (value == isCheckBox) return;
                isCheckBox = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(View));
            }
        }

        public override UserControl CreateView()
        {
            if (isCheckBox)
            {
                return new CheckBoxControl
                {
                    DataContext = this
                };
            }

            return new SwitchControl
            {
                DataContext = this
            };
        }

        public override bool HoldsValue => true;

        public override object GetValue() => Value;

        public override void SetValue(object obj)
        {
            Value = obj as bool? ?? false;
        }
    }
}

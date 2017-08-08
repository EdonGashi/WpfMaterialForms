﻿using System;
using System.Collections.Generic;

namespace MaterialForms.Wpf.FormBuilding
{
    public interface IFormProperty
    {
        string Name { get; }

        Type PropertyType { get; }

        Type DeclaringType { get; }

        bool CanWrite { get; }

        T GetCustomAttribute<T>() where T : Attribute;

        IEnumerable<T> GetCustomAttributes<T>() where T : Attribute;
    }
}

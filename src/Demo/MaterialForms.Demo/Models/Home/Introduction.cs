﻿using System.Windows.Data;
using Material.Application.Models;
using MaterialDesignThemes.Wpf;
using MaterialForms.Wpf.Annotations;
using MaterialForms.Wpf.Controls;

namespace MaterialForms.Demo.Models.Home
{
    public class Introduction : Model
    {
        private string yourName;

        [Title("WPF Material Forms")]

        [Heading("Introduction")]

        [Text("Welcome to Material Forms, a library for building dynamic forms.")]

        [Text("This library offers a declarative and MVVM friendly approach " +
              "to consistent forms with minimal boilerplate.")]

        [Text("The control you are currently seeing is a dynamic form, " +
              "as is the field below. Try entering your name:")]

        [Binding(UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged)]
        public string YourName
        {
            get => yourName;
            set
            {
                yourName = value;
                NotifyPropertyChanged();
            }
        }

        [Text("You entered: {Binding YourName}", IsVisible = "{Binding YourName|IsNotEmpty}")]

        [Text("Although everything shown here is possible in XAML, you will find " +
              "that for many cases this library will automate your V in MVVM " +
              "so that you can focus on more important tasks.")]

        [Text("To get started, read the following sections and see the examples.")]

        [Break]

        [Heading("Usage")]

        [Text("Using this library is straightforward. DynamicForm " +
              "is a control that will render controls bound " +
              "to an associated model. A model can be an object, a type, " +
              "a primitive, or a custom IFormDefinition.")]

        [Break]

        [Card(3)]
        [Break]
        [Text("<DynamicForm Model=\"{{Binding Model}}\" />", ShareLine = true)]
        [Action("copy", "COPY", Icon = "ContentCopy", Parameter = "<DynamicForm Model=\"{{Binding Model}}\" />",
            InsertAfter = false)]
        [Break]

        [Break(Height = 16d)]
        [Text("A DynamicForm has two key properties, the 'Model' property, which " +
              "represents the form being rendered, and the 'Context' property, which " +
              "allows models to access data outside of their scope, such as a selection " +
              "field or action handling.")]

        [Text("Reflection happens only the first time a model is inspected, after " +
              "which its definition is cached and subsequent renders will be quite fast.")]

        [Text("See live examples for a quick overview of features.", ShareLine = true)]
        [Action("examples", "VIEW EXAMPLES", InsertAfter = false)]
        [Break]
        [Text("The demo for the old v1 API is also available.", ShareLine = true)]
        [Action("oldexamples", "VIEW OLD DEMO", InsertAfter = false)]

        [Field(IsVisible = false)]
        public string AnnotationDummy { get; set; }
    }
}

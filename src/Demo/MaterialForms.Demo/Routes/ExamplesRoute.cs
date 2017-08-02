﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Material.Application.Infrastructure;
using Material.Application.Models;
using Material.Application.Routing;
using MaterialDesignThemes.Wpf;
using MaterialForms.Demo.Models;
using MaterialForms.Wpf;
using MaterialForms.Wpf.Forms;

namespace MaterialForms.Demo.Routes
{
    public class ExamplesRoute : Route, IActionHandler
    {
        private readonly INotificationService notificationService;

        private ExamplePresenter currentModel;

        public ExamplesRoute(INotificationService notificationService)
        {
            RouteConfig.Title = "Examples";
            RouteConfig.Icon = PackIconKind.ViewList;

            RouteConfig.RouteCommands.Add(Command("Validate model", PackIconKind.CheckAll, () => ModelState.Validate(CurrentModel.Object)));
            RouteConfig.RouteCommands.Add(Command("Reset model", PackIconKind.Undo, () => ModelState.Reset(CurrentModel.Object)));

            this.notificationService = notificationService;
        }

        public ExamplePresenter CurrentModel
        {
            get => currentModel;
            set
            {
                currentModel = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<ExamplePresenter> Models { get; private set; }

        protected override void RouteInitializing()
        {
            Models = new ObservableCollection<ExamplePresenter>(GetModels());
            CurrentModel = Models.FirstOrDefault();
        }

        private IEnumerable<ExamplePresenter> GetModels()
        {
            const double small = 320d;
            const double large = 540d;

            yield return new ExamplePresenter(new Login(), "Login", large);

            yield return new ExamplePresenter(new Settings(), "Settings", large);

            yield return new ExamplePresenter(new User(), "User", large);

            yield return new ExamplePresenter(new Alert
            {
                Message = "Item deleted."
            }, "Alert", small);

            yield return new ExamplePresenter(new Confirm
            {
                Message = "Discard draft?",
                PositiveAction = "DISCARD",
            }, "Confirm 1", small);

            yield return new ExamplePresenter(new Confirm
            {
                Title = "Use Google's location service?",
                Message = "Let Google help apps determine location. This means sending anonymous location data to Google, even when no apps are running.",
                PositiveAction = "AGREE",
                NegativeAction = "DISAGREE"
            }, "Confirm 2", small);


            yield return new ExamplePresenter(new Prompt<string>
            {
                Title = "Enter your name",
            }, "Prompt 1", small);

            yield return new ExamplePresenter(new Prompt<bool>
            {
                Message = "Discard draft?",
                PositiveAction = "DISCARD",
                Name = "Prevent future dialogs",
            }, "Prompt 2", small);

            yield return new ExamplePresenter(new DataTypes(), "Data types", large);
        }

        public void HandleAction(string action, object parameter)
        {
            notificationService.Notify($"Action '{action}'");
        }
    }
}

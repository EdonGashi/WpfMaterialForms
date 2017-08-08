﻿using System;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace MaterialForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MaterialFormsWindow : MetroWindow
    {
        public MaterialFormsWindow(WindowSession session, int dialogId = 0)
        {
            SetValue(SessionAssist.HostingSessionProperty, session);
            DataContext = session.Window;
            InitializeComponent();
            var view = session.Window.Dialog.View;
            ContentPresenter.Content = view;
            Background = view.Background;
            // We need to remove view background as it blocks dragmove behavior
            view.Background = null;
            DialogHost.Identifier = "DialogHost" + dialogId;
        }

        private void CloseDialogCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = e.Parameter as bool?;
            Close();
        }

        private void CloseDialogCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}

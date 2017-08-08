﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using MaterialForms;

namespace MaterialForms.Controls
{
    /// <summary>
    /// Interaction logic for SingleLineTextControl.xaml
    /// </summary>
    public partial class FileLoaderControl : UserControl
    {
        public FileLoaderControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = DataContext as SingleFileSchema;
            if (context == null)
            {
                return;
            }

            var dialog = new OpenFileDialog();
            if (context.Filter != null)
            {
                dialog.Filter = context.Filter;
            }

            if (dialog.ShowDialog() == true)
            {
                var fileName = dialog.FileName;
                context.Value = fileName;
            }
        }
    }
}

﻿using OpenLibrary_App.ViewModels;
using System.Windows;

namespace OpenLibrary_App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel()
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}

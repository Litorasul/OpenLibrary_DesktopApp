using System.Windows;

using OpenLibrary_DataAccess.Infrastructure;

namespace OpenLibrary_App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ApiClientHandler.InitializeClient();
    }
}

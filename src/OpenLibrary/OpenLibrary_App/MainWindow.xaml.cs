using OpenLibrary_DataAccess.Infrastructure;
using System.Windows;

namespace OpenLibrary_App;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ApiClientHandler.InitializeClient();
    }
}

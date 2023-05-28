using System.Threading.Tasks;
using System.Windows;

using OpenLibrary_DataAccess.Infrastructure;
using OpenLibrary_DataAccess.Models;
using OpenLibrary_DataAccess.Services;

namespace OpenLibrary_App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ListOfBooks? searchResult;
    private BooksSearchService booksSearchService;

    public MainWindow()
    {
        InitializeComponent();
        ApiClientHandler.InitializeClient();
        booksSearchService = new BooksSearchService();
    }

    private async void searchButton_Click(object sender, RoutedEventArgs e)
    {
        await Search(searchBar.Text);
        ShowSearchResults();
    }

    private async Task Search(string input)
    {
        searchResults.Items.Clear();
        searchResult = null;
        searchResult = await booksSearchService.GetBooksByAuthorAsync(input);
    }

    private void ShowSearchResults()
    {
        if (searchResult == null || searchResult.Docs.Count == 0)
        {
            searchResults.Items.Add("No Results Found!");
        }
        else
        {
            foreach (var item in searchResult.Docs)
            {
                string result = $"{item.Title} by {string.Join(", ", item.Author_Name)}";
                searchResults.Items.Add(result);
            }
        }
    }
}

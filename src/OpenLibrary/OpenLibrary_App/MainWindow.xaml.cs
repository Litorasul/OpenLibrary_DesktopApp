using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OpenLibrary_DataAccess.Infrastructure;
using OpenLibrary_DataAccess.Models;
using OpenLibrary_DataAccess.Services;

namespace OpenLibrary_App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public enum SearchType
{
    Full = 0,
    Author = 1,
    Title = 2,
}

public partial class MainWindow : Window
{
    private ListOfBooks? searchResult;
    private BooksSearchService booksSearchService;
    private BookDetailsService bookDetailsService;

    public MainWindow()
    {
        InitializeComponent();
        ApiClientHandler.InitializeClient();
        booksSearchService = new BooksSearchService();
        bookDetailsService = new BookDetailsService();
    }

    // Void ?????
    private async void searchButton_Click(object sender, RoutedEventArgs e)
    {
        SearchType type = CheckSearchType();

        switch (type)
        {
            case SearchType.Author:
                await SearchAuthor(searchBar.Text);
                break;
            case SearchType.Title:
                await SearchTitle(searchBar.Text);
                break;
            default:
                await SearchFull(searchBar.Text);
                break;
        }

        ShowSearchResults();
    }

    // Void ?????
    private async void searchResults_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
        var content = (ListBoxItem)item.Content;
        var selectedBook = (BookInList)content.Tag;

        var details = await bookDetailsService.GetBookDetailsAsync(selectedBook);
    }

    private SearchType CheckSearchType()
    {
        if (checkAuthor.IsChecked.Value && !checkTitle.IsChecked.Value)
        {
            return SearchType.Author;
        }
        else if (!checkAuthor.IsChecked.Value && checkTitle.IsChecked.Value)
        {
            return SearchType.Title;
        }
        return SearchType.Full;
    }

    private async Task SearchAuthor(string input)
    {
        searchResults.Items.Clear();
        searchResult = null;
        searchResult = await booksSearchService.GetBooksByAuthorAsync(input);
    }

    private async Task SearchTitle(string input)
    {
        searchResults.Items.Clear();
        searchResult = null;
        searchResult = await booksSearchService.GetBooksByTitleAsync(input);
    }

    private async Task SearchFull(string input)
    {
        searchResults.Items.Clear();
        searchResult = null;
        searchResult = await booksSearchService.GetBooksByFullSearchAsync(input);
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
                if (item.Author_Name != null)
                {
                    string result = $"{item.Title} by {string.Join(", ", item.Author_Name)}";
                    searchResults.Items.Add(new ListBoxItem() { Content = result, Tag = item });
                }

            }
        }
    }

}

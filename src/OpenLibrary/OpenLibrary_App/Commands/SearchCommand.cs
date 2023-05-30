using OpenLibrary_App.Models;
using OpenLibrary_App.ViewModels;
using OpenLibrary_DataAccess.Models;
using OpenLibrary_DataAccess.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenLibrary_App.Commands;

public class SearchCommand : CommandBase
{
    private SearchResultsViewModel searchResultsViewModel;
    private SearchType searchType => CheckSearchType();
    private List<BookInListModel> booksInList;
    private BooksSearchService booksSearchService;

    public SearchCommand(SearchResultsViewModel searchResultsViewModel)
    {
        this.searchResultsViewModel = searchResultsViewModel;
        booksSearchService = new BooksSearchService();
        booksInList = new List<BookInListModel>();
    }

    public async override void Execute(object? parameter)
    {
        await SearchAsync();
    }

    private async Task SearchAsync()
    {
        ListOfBooks books;
        switch (searchType)
        {
            case SearchType.Author:
                books = await booksSearchService.GetBooksByAuthorAsync(searchResultsViewModel.SearchText);
                break;
            case SearchType.Title:
                books = await booksSearchService.GetBooksByTitleAsync(searchResultsViewModel.SearchText);
                break;
            default:
                books = await booksSearchService.GetBooksByFullSearchAsync(searchResultsViewModel.SearchText);
                break;
        }
        foreach (var book in books.Docs)
        {
            var b = new BookInListModel
            {
                Key = book.Key,
                Title = book.Title,
                Authors = book.Author_Name
            };
            booksInList.Add(b);
        }
    }

    private SearchType CheckSearchType()
    {
        if (searchResultsViewModel.AuthorType && !searchResultsViewModel.TitleType)
        {
            return SearchType.Author;
        }
        else if (!searchResultsViewModel.AuthorType && searchResultsViewModel.TitleType)
        {
            return SearchType.Title;
        }

        return SearchType.Full;
    }
}

public enum SearchType
{
    Full = 0,
    Author = 1,
    Title = 2,
}

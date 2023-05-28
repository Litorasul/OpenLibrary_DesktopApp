using OpenLibrary_DataAccess.Infrastructure;
using OpenLibrary_DataAccess.Models;

using Newtonsoft.Json;

using static OpenLibrary_DataAccess.Infrastructure.GlobalVariables;
using static OpenLibrary_DataAccess.Infrastructure.Helpers;

namespace OpenLibrary_DataAccess.Services;

public class BooksSearchService
{
    private ListOfBooks? books;

    public async Task<ListOfBooks> GetBooksByAuthorAsync(string input)
    {
        string author = PrepareStringParameterForUrl(input);

        var url = $"{OPEN_LIBRARY_BASE_URL}{OPEN_LIBRARY_AUTHOR_SEARCH}{author}";

        await GetBooksAsync(url);

        return books;
    } 

    public async Task<ListOfBooks> GetBooksByTitleAsync(string input)
    {
        string title = PrepareStringParameterForUrl(input);

        var url = $"{OPEN_LIBRARY_BASE_URL}{OPEN_LIBRARY_TITLE_SEARCH}{title}";

        await GetBooksAsync(url);

        return books;
    }

    public async Task<ListOfBooks> GetBooksByFullSearchAsync(string input)
    {
        string parameter = PrepareStringParameterForUrl(input);
        
        var url = $"{OPEN_LIBRARY_BASE_URL}{OPEN_LIBRARY_FULL_SEARCH}{parameter}";

        await GetBooksAsync(url);

        return books;
    }

    private async Task GetBooksAsync(string url)
    {
        HttpResponseMessage response = await ApiClientHandler.ApiClient!.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            books = JsonConvert.DeserializeObject<ListOfBooks>(json);
        }
    }

    private static string PrepareStringParameterForUrl(string str)
    {
        var strArr = SplitStringBySpace(str);
        var result = JoinStringArrByPlus(strArr);
        return result;
    }
}

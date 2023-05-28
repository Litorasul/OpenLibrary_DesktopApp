using Newtonsoft.Json;

using OpenLibrary_DataAccess.Infrastructure;
using OpenLibrary_DataAccess.Models;

using static OpenLibrary_DataAccess.Infrastructure.GlobalVariables;

namespace OpenLibrary_DataAccess.Services;

public class BookDetailsService
{
    public async Task<BookFullDetails> GetBookDetailsAsync(BookInList incomingBook)
    {
        if (incomingBook == null)
        {
            return null;
        }

        string isbnUrl = $"{OPEN_LIBRARY_ISBN}{incomingBook.Isbn[0]}{OPEN_LIBRARY_JSON_EXTENTION}";
        string keyUrl = $"{incomingBook.Key}{OPEN_LIBRARY_JSON_EXTENTION}";

        var isbnBook = await GetBookByIsbnAsync(isbnUrl); 
        var keyBook = await GetBookByKeyAsync(keyUrl);

        // All or nothing ???
        if (isbnBook == null || keyBook == null)
        {
            return null;
        }

        return new BookFullDetails
        {
            Title = incomingBook.Title,
            Author_Name = incomingBook.Author_Name,
            Publish_Date = isbnBook.Publish_Date,
            Covers = isbnBook.Covers,
            Subjects = keyBook.Subjects,
            Description = keyBook.Description
        };
    }

    private async Task<BookIsbnDetails> GetBookByIsbnAsync(string url)
    {
        HttpResponseMessage response = await ApiClientHandler.ApiClient!.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var isbnBook = JsonConvert.DeserializeObject<BookIsbnDetails>(json);
            return isbnBook;
        }
        return null;
    }
    private async Task<BookKeyDetails> GetBookByKeyAsync(string url)
    {
        HttpResponseMessage response = await ApiClientHandler.ApiClient!.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var keyBook = JsonConvert.DeserializeObject<BookKeyDetails>(json);
            return keyBook;
        }
        return null;
    }
}

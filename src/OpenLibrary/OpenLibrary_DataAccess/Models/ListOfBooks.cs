namespace OpenLibrary_DataAccess.Models;

public class ListOfBooks
{
    public int NumFound { get; set; }

    public List<BookInList> Docs { get; set; }
}

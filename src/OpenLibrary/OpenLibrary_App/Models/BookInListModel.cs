using System.Collections.Generic;

namespace OpenLibrary_App.Models;

public class BookInListModel
{
    public string Key { get; set; }
    public string Title { get; set; }
    public List<string> Authors { get; set; }
}

using OpenLibrary_App.Models;
using System.Collections.Generic;

namespace OpenLibrary_App.ViewModels;

public class BookInListViewModel : ViewModelBase
{
    private readonly BookInListModel bookInList;

	public string Title => bookInList.Title;
	public string Author => string.Join(", ", bookInList.Authors);

	 public string Key => bookInList.Key;
	public List<string> Isbn => bookInList.Isbn;

	public BookInListViewModel(BookInListModel book)
	{
		bookInList = book;
	}
}

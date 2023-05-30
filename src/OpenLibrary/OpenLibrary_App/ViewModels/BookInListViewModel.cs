using OpenLibrary_App.Models;

namespace OpenLibrary_App.ViewModels;

public class BookInListViewModel : ViewModelBase
{
    private readonly BookInListModel bookInList;

	public string Title => bookInList.Title;
	public string Author => string.Join(", ", bookInList.Authors);

	public BookInListViewModel(BookInListModel book)
	{
		bookInList = book;
	}
}

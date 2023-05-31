using OpenLibrary_App.Commands;
using OpenLibrary_App.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OpenLibrary_App.ViewModels;

public class SearchResultsViewModel : ViewModelBase
{
    private string searchText;
    public string SearchText
    {
        get
        {
            return searchText;
        }
        set
        {
            searchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }

    private bool authorType;
    public bool AuthorType
    {
        get
        {
            return authorType;
        }
        set
        {
            authorType = value;
            OnPropertyChanged(nameof(AuthorType));
        }
    }

    private bool titleType;
    public bool TitleType
    {
        get
        {
            return titleType;
        }
        set
        {
            titleType = value;
            OnPropertyChanged(nameof(TitleType));
        }
    }

    public ICommand SearchCommand { get; }
    public ICommand ChooseItemCommand { get; }

    private ObservableCollection<BookInListViewModel> bookInList;
    public IEnumerable<BookInListViewModel> BookInList => bookInList;

    public SearchResultsViewModel()
    {
        bookInList = new ObservableCollection<BookInListViewModel>();
        SearchCommand = new SearchCommand(this, bookInList);
        ChooseItemCommand = new ChooseItemCommand();
    }
}

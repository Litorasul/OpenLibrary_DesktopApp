using OpenLibrary_App.Models;
using OpenLibrary_App.ViewModels;
using OpenLibrary_App.Views;
using OpenLibrary_DataAccess.Models;
using OpenLibrary_DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace OpenLibrary_App.Commands;

public class ChooseItemCommand : CommandBase
{
    private BookDetailsService bookDetailsService;

    public ChooseItemCommand()
    {
        bookDetailsService = new BookDetailsService();
    }
    public override async void Execute(object? parameter)
    {
        var selectedBook = (BookInListViewModel)parameter;
        BookInList book = new BookInList
        {
            Key = selectedBook.Key,
            Title=selectedBook.Title,
            Author_Name= GetAuthorList(selectedBook.Author),
            Isbn= selectedBook.Isbn
        };
        var details = await bookDetailsService.GetBookDetailsAsync(book);
        var model = new BookDetailsModel
        {
            Title = details.Title,
            Author_Name = details.Author_Name,
            Subjects = details.Subjects,
            Description = details.Description, 
            Covers = details.Covers,
            Publish_Date = details.Publish_Date
        };
        BookDetailsView view = new BookDetailsView();
        var viewModel = new BookDetailsViewModel(model);
        var window = new Window();
        window.Content = view;
        window.DataContext = viewModel;
        window.Show();
    }

    private List<string> GetAuthorList(string author)
    {
        return author.Split(", ").ToList();
    }
}

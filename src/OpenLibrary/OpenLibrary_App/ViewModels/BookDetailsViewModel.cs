using OpenLibrary_App.Models;

namespace OpenLibrary_App.ViewModels;

public class BookDetailsViewModel:ViewModelBase
{
    private readonly BookDetailsModel bookDetailsModel;

    public string Title => bookDetailsModel.Title;
    public string Author => string.Join(", ", bookDetailsModel.Author_Name);
    public string Publish_Date => bookDetailsModel.Publish_Date;
    public string Cover => bookDetailsModel.Covers[0];
    public string Subject => bookDetailsModel.Subjects[0];
    public string Description => bookDetailsModel.Description;

    public BookDetailsViewModel(BookDetailsModel model)
    {
        this.bookDetailsModel = model;
    }
}

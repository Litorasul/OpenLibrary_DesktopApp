namespace OpenLibrary_DataAccess.Models;

public class BookFullDetails
{
    public string Title { get; set; }
    public List<string> Author_Name { get; set; }
    public string Publish_Date { get; set; }
    public List<string> Covers { get; set; }
    public List<string> Subjects { get; set; }
    public string Description { get; set; }
}

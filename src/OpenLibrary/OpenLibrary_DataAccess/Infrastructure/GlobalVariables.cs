namespace OpenLibrary_DataAccess.Infrastructure;

public static class GlobalVariables
{
    public const string JSON_CONTENT_TYPE = "application/json";

    #region Open Library URL parts

    public const string OPEN_LIBRARY_BASE_URL = "https://openlibrary.org/search.json?";
    public const string OPEN_LIBRARY_FULL_SEARCH = "q=";
    public const string OPEN_LIBRARY_TITLE_SEARCH = "title=";
    public const string OPEN_LIBRARY_AUTHOR_SEARCH = "author=";

    #endregion
}

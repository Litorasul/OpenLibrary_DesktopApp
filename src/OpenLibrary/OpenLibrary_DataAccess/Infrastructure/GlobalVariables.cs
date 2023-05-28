namespace OpenLibrary_DataAccess.Infrastructure;

public static class GlobalVariables
{
    public const string JSON_CONTENT_TYPE = "application/json";

    #region Open Library URL parts

    public const string OPEN_LIBRARY_BASE_URL = "https://openlibrary.org";
    public const string OPEN_LIBRARY_FULL_SEARCH = "/search.json?q=";
    public const string OPEN_LIBRARY_TITLE_SEARCH = "/search.json?title=";
    public const string OPEN_LIBRARY_AUTHOR_SEARCH = "/search.json?author=";
    public const string OPEN_LIBRARY_ISBN = "/isbn/";
    public const string OPEN_LIBRARY_JSON_EXTENTION = ".json";

    #endregion
}

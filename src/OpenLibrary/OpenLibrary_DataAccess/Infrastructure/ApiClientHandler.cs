using System.Net.Http.Headers;
using static OpenLibrary_DataAccess.Infrastructure.GlobalVariables;

namespace OpenLibrary_DataAccess.Infrastructure;

public static class ApiClientHandler
{
    public static HttpClient? ApiClient { get; set; }

    public static void InitializeClient()
    {
        ApiClient = new HttpClient();
        ApiClient.BaseAddress = new Uri(OPEN_LIBRARY_BASE_URL);
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON_CONTENT_TYPE));
    }
}

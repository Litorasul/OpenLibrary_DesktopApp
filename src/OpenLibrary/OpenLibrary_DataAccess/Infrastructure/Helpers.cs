namespace OpenLibrary_DataAccess.Infrastructure;

public static class Helpers
{
    public static string[] SplitStringBySpace(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string JoinStringArrByPlus(string[] input)
    {
        return string.Join("+", input);
    }
}

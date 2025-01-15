public static class CacheKeys
{
    private const string Prefix = "Products";
    private static readonly HashSet<string> ActiveKeys = new();

    public static string GetProductListKey(int page)
    {
        var key = $"{Prefix}_List_Page_{page}";
        ActiveKeys.Add(key);
        return key;
    }

    public static string GetProductDetailsKey(int id)
    {
        var key = $"{Prefix}_Details_{id}";
        ActiveKeys.Add(key);
        return key;
    }

    public static IEnumerable<string> GetAllProductListKeys()
    {
        return ActiveKeys.Where(k => k.Contains($"{Prefix}_List_Page_"));
    }

    public static IEnumerable<string> GetAllProductKeys()
    {
        return ActiveKeys;
    }

    public static void RemoveKey(string key)
    {
        ActiveKeys.Remove(key);
    }
}

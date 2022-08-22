namespace varGis.essai;

public static class Scan
{
    public static IEnumerable<string> SearchLink(string directory)
    {
        return Scanner(directory).Where(s => s.EndsWith(".lnk"));
    }

    private static IEnumerable<string> Scanner(string path)
    {
        return Directory.GetFileSystemEntries(path, "*.*",SearchOption.AllDirectories);
    }
}
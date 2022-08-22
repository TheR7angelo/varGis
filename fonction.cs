using varGis.essai;

namespace varGis;

public static partial class Fonction
{
    public static Structs.QgisStruct MostRecentQgis()
    {
        var strucs = new List<Structs.QgisStruct>();
        var paths = Scan.SearchLink(Const.DirStartProgram)
            .Where(s => s.ToLower().Contains("qgis desktop") && !s.ToLower().Contains("grass"));
        
        foreach (var path in paths)
        {
            var split = path.Split("\\").Last();
            var verMatches = OnlyNumber().Matches(split);
            
            var version = new[]
            {
                int.Parse(verMatches[0].ToString()),
                int.Parse(verMatches[1].ToString()),
                int.Parse(verMatches[2].ToString())
            };

            var struc = new Structs.QgisStruct()
            {
                Name = split,
                WorkingDirectory = Getter.GetShortcutTargetFile(path),
                VersionStr = string.Join(".", version),
                VersionInt = int.Parse(string.Join("", version)),
                VersionInts = version
            };
            strucs.Add(struc);
        }

        return strucs.Find(
            x => x.VersionStr.Equals(strucs.Max(
                    x => x.VersionStr)));
    }
    public static string? StrInVariable(IEnumerable<string?> variables, string logiciel)
    {
        return variables.FirstOrDefault(variable => variable != null && variable.ToLower().Contains(logiciel));
    }
}
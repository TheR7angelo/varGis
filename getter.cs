using System.Collections;
using System.Security.Principal;
using Lnk;

namespace varGis;

public static class Getter
{
    public static string? GetQgisEnv()
    {
        var targets = new List<EnvironmentVariableTarget>
            { EnvironmentVariableTarget.User, EnvironmentVariableTarget.Machine };
        const string logiciel = "qgis";

        foreach (var environment in targets)
        {
            var variables = GetVarEnv("path", environment);
            var path = Fonction.StrInVariable(variables, logiciel);
            if (path != null)
            {
                return path;
            }
        }

        return null;
    }

    private static IEnumerable<string?> GetVarEnv(string env,
        EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
    {
        var val = Environment.GetEnvironmentVariable(env, target);
        return val != null ? val.Split(";") : new[] { "" };
    }
    
    public static string GetShortcutTargetFile(string shortcutFilename)
    {
        var lnk = Lnk.Lnk.LoadFile(shortcutFilename);

        var paths = lnk.LocalPath.Split("\"").First().Split("\\");
        paths = paths.SkipLast(1).ToArray();

        return string.Join("\\", paths);
    }
}
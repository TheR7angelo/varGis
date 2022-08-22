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

    // public static float GetQgisVer(string path)
    // {
    //     path = @"C:\Program Files\QGIS\QGIS 2.18\bin\qgis-ltr-bin.exe";
    //     var versionInfo = FileVersionInfo.GetVersionInfo(path);
    //     var version = versionInfo.FileVersion;
    //
    //     return 0f;
    // }

    // public static List<Structs.QgisStruct> GetAllQgis()
    // {
    //     #pragma warning disable CA1416
    //     var valueSubKey = RegistryKey.OpenBaseKey(
    //         RegistryHive.LocalMachine,
    //         RegistryView.Registry64).OpenSubKey(@"SOFTWARE\", false)
    //         ?.GetSubKeyNames();
    //     #pragma warning restore CA1416
    //
    //     if (valueSubKey == null) return null;
    //     foreach (var subKey in valueSubKey)
    //     {
    //         if (subKey.ToLower().Contains("qgis"))
    //         {
    //             var root = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\{subKey}");
    //             
    //         }
    //     }
    //
    //     return null;
    // }

    private static IEnumerable<string?> GetVarEnv(string env,
        EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
    {
        var val = Environment.GetEnvironmentVariable(env, target);
        return val != null ? val.Split(";") : new[] { "" };
    }
    
    public static string GetShortcutTargetFile(string shortcutFilename)
    {
        var lnk = Lnk.Lnk.LoadFile(shortcutFilename);
        Console.WriteLine(lnk);

        return string.Empty;
    }
}
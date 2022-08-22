using Microsoft.Win32;

namespace varGis.essai;

// Ne fonctionne pas

public class registre
{
    private static void GetInstalledApps()
    {
        // string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        // using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
        // {
        //     foreach (string skName in rk.GetSubKeyNames())
        //     {
        //         using (RegistryKey sk = rk.OpenSubKey(skName))
        //         {
        //             try
        //             {
        //                 Console.WriteLine(sk.GetValue("DisplayName"));
        //             }
        //             catch (Exception ex)
        //             { }
        //         }
        //     }
        // }
            
        string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
        {
            foreach (string skName in rk.GetSubKeyNames())
            {
                using (RegistryKey sk = rk.OpenSubKey(skName))
                {
                    try
                    {
                        Console.WriteLine($"{skName}, {sk.GetValue("DisplayName")}: {sk.GetValue("InstallLocation")}");
                        Console.WriteLine("############################################################################");
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }
        Console.WriteLine("hey");
            
    }
}
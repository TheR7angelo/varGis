using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace varGis.essai;

// Ne fonctionne pas

public class MsiPro
{
    [DllImport("msi.dll", CharSet = CharSet.Unicode)]
    static extern Int32 MsiGetProductInfo(string product, string property,
        [Out] StringBuilder valueBuf, ref Int32 len);

    [DllImport("msi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern int MsiEnumProducts(int iProductIndex, 
        StringBuilder lpProductBuf);

    public static void t()
    {
            //!!!!! Must be launched with a domain administrator user!!!!!
            Console.ForegroundColor = ConsoleColor.Green;
            StringBuilder sbOutFile = new StringBuilder();
            Console.WriteLine("DisplayName;IdentifyingNumber");
            sbOutFile.AppendLine("Machine;DisplayName;Version");

            //Retrieve machine name from the file :File_In/collectionMachines.txt
            //string[] lines = new string[] { "NameMachine" };
            string[] lines = File.ReadAllLines(@"File_In/collectionMachines.txt");
            foreach (var machine in lines)
            {
                //Retrieve the list of installed programs for each extrapolated machine name
                var registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                using (Microsoft.Win32.RegistryKey key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machine).OpenSubKey(registry_key))
                {
                    foreach (string subkey_name in key.GetSubKeyNames())
                    {
                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {
                            //Console.WriteLine(subkey.GetValue("DisplayName"));
                            //Console.WriteLine(subkey.GetValue("IdentifyingNumber"));
                            if (subkey.GetValue("DisplayName") != null && subkey.GetValue("DisplayName").ToString().Contains("Visual Studio"))
                            {
                                Console.WriteLine(string.Format("{0};{1};{2}", machine, subkey.GetValue("DisplayName"), subkey.GetValue("Version")));
                                sbOutFile.AppendLine(string.Format("{0};{1};{2}", machine, subkey.GetValue("DisplayName"), subkey.GetValue("Version")));
                            }
                        }
                    }
                }
            }
            //CSV file creation
            var fileOutName = string.Format(@"File_Out\{0}_{1}.csv", "Software_Inventory", DateTime.Now.ToString("yyyy_MM_dd_HH_mmssfff"));
            using (var file = new System.IO.StreamWriter(fileOutName))
            {

                file.WriteLine(sbOutFile.ToString());
            }
            //Press enter to continue 
            Console.WriteLine("Press enter to continue !");
            Console.ReadLine();
    }
}
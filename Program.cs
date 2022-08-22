
namespace varGis
{
    public static class Env
    {
        private static void Main()
        {
            var envQgis = Getter.GetQgisEnv();
            
            if (envQgis != string.Empty)
            {
                MajQgis();
            }
            else
            {
                Console.WriteLine("Une variable d'environement à étais trouver pour Qgis\nVous les vous la métre à jour ?(o/n)");
                var reponse = Console.ReadLine();

                if (reponse.Equals("o"))
                {
                    MajQgis();
                }
            }
        }

        private static void MajQgis()
        {
            var t = Fonction.MostRecentQgis();
            essai.Scan.SearchLink(Const.DirStartProgram);
            // var t = Getter.GetAllQgis();
            // var versionQgis = Getter.GetQgisVer(qgisPath);
            // Console.WriteLine(qgisPath);
        }
    }
}


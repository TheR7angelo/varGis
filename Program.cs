
namespace varGis
{
    public static class Env
    {
        private static void Main()
        {
            var envQgis = Getter.GetQgisEnv();
            
            if (envQgis == string.Empty)
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
            var qgis = Fonction.MostRecentQgis();
            Console.WriteLine(qgis);

        }
    }
}


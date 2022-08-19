using System;

namespace varGis
{
    public static class Env
    {
        private static void Main()
        {
            var env = Fonction.GetVarEnv("path");
            foreach (var e in env)
            {
                Console.WriteLine(e);
            }
        }
    }
}


namespace varGis;

public static class Fonction
{
    public static string[] GetVarEnv(string env, EnvironmentVariableTarget target=EnvironmentVariableTarget.User)
    {
        var val = Environment.GetEnvironmentVariable(env, target);
        return val != null ? val.Split(";") : new[] {""};
    }
}
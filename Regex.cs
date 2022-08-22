using System.Text.RegularExpressions;

namespace varGis;

public partial class Fonction
{
    [RegexGenerator("\\d+")]
    private static partial Regex OnlyNumber();
}
using System.Text.RegularExpressions;

namespace Application.Util
{
    public static class RegexUtil
    {
        public static string SomenteNumero(string texto)
        {
            return Regex.Replace(texto, @"[^\d]", "");
        }
    }
}

using System.Text.RegularExpressions;

namespace SistemaDeGestaoEscolar.Common
{
    public static class StringExtension
    {
        public static string ToSnakeCase(this string textoOriginal)
        {
            var ret = "";

            if (!string.IsNullOrEmpty(textoOriginal))
            {
                var inicioUnderscores = Regex.Match(textoOriginal, @"^ _+");
                ret = inicioUnderscores + Regex.Replace(textoOriginal, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
            }
            return ret;
        }
    }
}

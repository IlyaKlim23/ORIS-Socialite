using System.Globalization;

namespace Socialite.Api.Core.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Возвращает строку с первым заглавным символом
    /// </summary>
    /// <param name="source">Исходная строка</param>
    public static string ToUpperFirstCharString(this string source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return source.Remove(1).ToUpper(CultureInfo.InvariantCulture) + source.Substring(1);
    }
}
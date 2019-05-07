using System.Text.RegularExpressions;

namespace Copernicus.Common.Extensions
{
    public static class ValidationExtensions
    {
        public const string EmailPattern =
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public const string CulturePattern = @"^[a-z]{2}(-[A-Z]{2})*$";

        public static bool IsEmail(this string email)
            => new Regex(EmailPattern, RegexOptions.IgnoreCase).IsMatch(email);


        public static bool IsCulture(this string culture)
            => new Regex(CulturePattern).IsMatch(culture);
    }
}
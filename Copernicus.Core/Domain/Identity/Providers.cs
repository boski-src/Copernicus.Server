namespace Copernicus.Core.Domain.Identity
{
    public static class Providers
    {
        public const string Facebook = "facebook";

        public static bool IsValid(string value) => value == Facebook;
    }
}
namespace Copernicus.Core.Domain.Identity
{
    public static class Roles
    {
        public const string Admin = "admin";
        public const string User = "user";

        public static bool IsValid(string value) => value == Admin || value == User;
    }
}
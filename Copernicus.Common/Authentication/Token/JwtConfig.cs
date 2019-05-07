namespace Copernicus.Common.Authentication.Token
{
    public class JwtConfig
    {
        public string HeaderName { get; set; }
        public string Name { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int LifetimeInMinutes { get; set; }
    }
}
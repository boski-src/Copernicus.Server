namespace Copernicus.Common.Authentication
{
    public class AdminAttribute : AuthAttribute
    {
        public AdminAttribute() : base("admin")
        {
        }
    }
}
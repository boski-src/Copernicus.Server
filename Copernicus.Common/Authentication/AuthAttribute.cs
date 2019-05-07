using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Copernicus.Common.Authentication
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(string policy = null) : base(policy)
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
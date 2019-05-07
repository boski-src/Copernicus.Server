using System.Threading.Tasks;
using AutoMapper;
using Copernicus.Application.Identity.Auth;
using Copernicus.Common.CQRS;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IMapper mapper, IDispatcher dispatcher, IAuthService authService)
            : base(mapper, dispatcher)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> SignInViaFacebook(SignInViaFacebook command)
        {
            var token = await _authService.SignInViaFacebook(command.AccessToken);

            if (string.IsNullOrWhiteSpace(token))
                return BadRequest();

            return Ok(new { Token = token });
        }
    }
}
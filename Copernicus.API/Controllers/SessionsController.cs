using System.Threading.Tasks;
using AutoMapper;
using Copernicus.Application.Identity.Commands;
using Copernicus.Common.Authentication;
using Copernicus.Common.CQRS;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    [Auth]
    public class SessionsController : BaseController
    {
        public SessionsController(IMapper mapper, IDispatcher dispatcher) : base(mapper, dispatcher)
        {
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            await Execute(new RefreshSession());
            return Ok();
        }

        [HttpPost("destroy")]
        public async Task<IActionResult> Destroy()
        {
            await Execute(new DestroySession());
            return Ok();
        }
    }
}

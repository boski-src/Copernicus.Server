using System.Threading.Tasks;
using AutoMapper;
using Copernicus.API.Dtos;
using Copernicus.Application.Identity.Queries;
using Copernicus.Application.Players.Queries;
using Copernicus.Common.CQRS;
using Copernicus.Core.Domain.Players;
using Copernicus.Core.Domain.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IMapper mapper, IDispatcher dispatcher) : base(mapper, dispatcher)
        {
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get([FromRoute] GetUser query)
        {
            return Object<User, UserDto>(await Query(query));
        }
    }
}
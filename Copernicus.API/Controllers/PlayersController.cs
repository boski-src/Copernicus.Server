using System.Threading.Tasks;
using AutoMapper;
using Copernicus.API.Dtos;
using Copernicus.Application.Players.Queries;
using Copernicus.Common.CQRS;
using Copernicus.Core.Domain.Players;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    public class PlayersController : BaseController
    {
        public PlayersController(IMapper mapper, IDispatcher dispatcher) : base(mapper, dispatcher)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Collection<Player, PlayerDto>(await Query(new GetTopPlayers()));
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get([FromRoute] GetPlayer query)
        {
            return Object<Player, PlayerDto>(await Query(query));
        }
    }
}
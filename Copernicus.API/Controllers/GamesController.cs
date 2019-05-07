using System;
using System.Threading.Tasks;
using AutoMapper;
using Copernicus.API.Dtos;
using Copernicus.Application.Games.Commands;
using Copernicus.Application.Games.Queries;
using Copernicus.Common.Authentication;
using Copernicus.Common.CQRS;
using Copernicus.Core.Domain.Games;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    public class GamesController : BaseController
    {
        public GamesController(IMapper mapper, IDispatcher dispatcher) : base(mapper, dispatcher)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetGames query)
        {
            return PagedCollection<Game, GameDetailsDto>(await Query(query));
        }

        [HttpPost("code")]
        public async Task<IActionResult> GetDetailtByCode([FromBody] GetGameDetailsByCode query)
        {
            return Object<Game, GameDetailsDto>(await Query(query));
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails([FromRoute] GetGameDetails query)
        {
            return Object<Game, GameDetailsDto>(await Query(query));
        }

        [Auth]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetGame query)
        {
            return Object<Game, GameDto>(await Query(query));
        }

        [Auth]
        [HttpPost]
        public async Task<IActionResult> Create(CreateGame command)
        {
            command.Id = Guid.NewGuid();
            await Execute(command);
            return Created($"games/{command.Id}", new { command.Id });
        }

        [Auth]
        [HttpPost("{id}/start")]
        public async Task<IActionResult> Start(Guid id, StartGame command)
        {
            command.GameId = id;
            await Execute(command);
            return NoContent();
        }

        [Auth]
        [HttpPost("{id}/end")]
        public async Task<IActionResult> Stop(Guid id, EndGame command)
        {
            command.GameId = id;
            await Execute(command);
            return NoContent();
        }

        [Auth]
        [HttpPost("{id}/join")]
        public async Task<IActionResult> Join(Guid id, JoinToGame command)
        {
            command.GameId = id;
            await Execute(command);
            return NoContent();
        }

        [Auth]
        [HttpPost("{id}/leave")]
        public async Task<IActionResult> Leave(Guid id, LeaveFromGame command)
        {
            command.GameId = id;
            await Execute(command);
            return NoContent();
        }

        [Auth]
        [HttpPost("{id}/answer-question")]
        public async Task<IActionResult> Leave(Guid id, CreateAnswer command)
        {
            command.GameId = id;
            await Execute(command);
            return NoContent();
        }

        [Auth]
        [HttpPost("{id}/change-question")]
        public async Task<IActionResult> ChangeQuestion(Guid id, ChangeQuestion command)
        {
            command.GameId = id;
            await Execute(command);
            return NoContent();
        }
    }
}

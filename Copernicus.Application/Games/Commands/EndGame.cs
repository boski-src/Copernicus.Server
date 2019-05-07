using System;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Games.Commands
{
    public class EndGame : IAuthCommand
    {
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
    }
}
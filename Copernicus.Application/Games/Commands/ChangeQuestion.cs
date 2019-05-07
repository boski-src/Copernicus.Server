using System;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Games.Commands
{
    public class ChangeQuestion : IAuthCommand
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
    }
}
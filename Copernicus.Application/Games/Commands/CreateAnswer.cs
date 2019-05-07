using System;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Games.Commands
{
    public class CreateAnswer : IAuthCommand
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public Guid QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
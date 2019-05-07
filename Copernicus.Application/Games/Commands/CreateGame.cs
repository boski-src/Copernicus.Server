using System;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Games.Commands
{
    public class CreateGame : IAuthCommand
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrimaryLanguage { get; set; }
        public int MaxQuestions { get; set; }
    }
}
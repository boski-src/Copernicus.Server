using System;
using System.Collections.Generic;
using Copernicus.Core.Domain.Games;

namespace Copernicus.API.Dtos
{
    public class GameDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string PrimaryLanguage { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
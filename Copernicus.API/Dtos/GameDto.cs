using System;
using System.Collections.Generic;
using Copernicus.Core.Domain.Games;

namespace Copernicus.API.Dtos
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string PrimaryLanguage { get; set; }
        public Guid CurrentQuestionId { get; set; }

        public List<Winner> Winners { get; set; }
        public List<MemberDto> Members { get; set; }
        public List<GameQuestionDto> Questions { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
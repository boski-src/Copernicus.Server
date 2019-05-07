using System;
using System.Collections.Generic;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.API.Dtos
{
    public class GameQuestionDto
    {
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public string Query { get; set; }
        public string Image { get; set; }
        public long Time { get; set; }
        public List<ChoiceDto> Choices { get; set; }
        public Translations Translations { get; set; }
    }
}
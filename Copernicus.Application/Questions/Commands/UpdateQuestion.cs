using System;
using System.Collections.Generic;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.Application.Questions.Commands
{
    public class UpdateQuestion : ICommand
    {
        public Guid Id { get; set; }
        public string Query { get; set; }
        public string Image { get; set; }
        public long Time { get; set; }
        public ISet<Choice> Choices { get; set; }
        public Translations Translations { get; set; }
    }
}
using System;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Questions.Commands
{
    public class DeleteQuestion : ICommand
    {
        public Guid Id { get; set; }
    }
}
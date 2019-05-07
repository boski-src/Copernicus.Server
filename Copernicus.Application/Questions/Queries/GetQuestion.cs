using System;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.Application.Questions.Queries
{
    public class GetQuestion : IQuery<Question>
    {
        public Guid Id { get; set; }
    }
}
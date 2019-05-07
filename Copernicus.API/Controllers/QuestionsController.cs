using System;
using System.Threading.Tasks;
using AutoMapper;
using Copernicus.API.Dtos;
using Copernicus.Application.Questions.Commands;
using Copernicus.Application.Questions.Queries;
using Copernicus.Common.Authentication;
using Copernicus.Common.CQRS;
using Copernicus.Core.Domain.Questions;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    [Auth]
    public class QuestionsController : BaseController
    {
        public QuestionsController(IMapper mapper, IDispatcher dispatcher) : base(mapper, dispatcher)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetQuestion query)
        {
            return Object<Question, QuestionDto>(await Query(query));
        }

        [Admin]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetQuestions query)
        {
            return PagedCollection<Question, QuestionDto>(await Query(query));
        }
        
        [Admin]
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchQuestions query)
        {
            return Collection<Question, QuestionDto>(await Query(query));
        }

        [Admin]
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestion command)
        {
            command.Id = Guid.NewGuid();
            await Execute(command);
            return Created($"questions/{command.Id}", new { command.Id });
        }

        [Admin]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateQuestion command)
        {
            command.Id = id;
            await Execute(command);
            return Ok();
        }

        [Admin]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteQuestion command)
        {
            await Execute(command);
            return Ok();
        }
    }
}
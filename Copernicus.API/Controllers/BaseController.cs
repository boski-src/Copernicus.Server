using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Copernicus.Common.CQRS;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Common.Types;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDispatcher _dispatcher;

        public BaseController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        protected IActionResult PagedCollection<T, TDto>(PagedList<T> pagedList)
            where T : class where TDto : class
        {
            if (pagedList.IsEmpty)
            {
                return Ok(Enumerable.Empty<TDto>());
            }

            AddPagedHeaders(pagedList);
            return Ok(_mapper.Map<List<TDto>>(pagedList.Items));
        }

        protected IActionResult Collection<T, TDto>(List<T> collection) where T : class where TDto : class
        {
            if (collection.Count <= 0)
            {
                return Ok(Enumerable.Empty<TDto>());
            }

            return Ok(_mapper.Map<List<TDto>>(collection));
        }

        protected IActionResult Object<T, TDto>(T item) where T : class where TDto : class
        {
            if (item == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TDto>(item));
        }

        protected async Task<TResult> Query<TResult>(IQuery<TResult> query) where TResult : class
        {
            if (typeof(IAuthQuery<TResult>).IsInstanceOfType(query))
            {
                ((IAuthQuery<TResult>) query).UserId = GetUserId();
            }

            return await _dispatcher.DispatchQuery(query);
        }

        protected async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (typeof(IAuthCommand).IsInstanceOfType(command))
            {
                ((IAuthCommand) command).UserId = GetUserId();
            }

            await _dispatcher.DispatchCommand(command);
        }

        protected void AddPagedHeaders<T>(PagedList<T> pagedList) where T : class
        {
            AddResponseHeader("X-Total", pagedList.TotalResults);
            AddResponseHeader("X-Total-Pages", pagedList.TotalPages);
            AddResponseHeader("X-Per-Page", pagedList.Limit);
            AddResponseHeader("X-Page", pagedList.Page);

            var prevPage = pagedList.Page > 1 ? pagedList.Page - 1 : pagedList.Page;
            AddResponseHeader("X-Previous-Page", prevPage);

            var nextPage = pagedList.TotalPages > pagedList.Page ? pagedList.Page + 1 : pagedList.Page;
            AddResponseHeader("X-Next-Page", nextPage);
        }

        protected void AddResponseHeader(string name, object value)
        {
            Response.Headers.Add(name, value.ToString());
        }

        protected string GetAccessTokenFromBearerHeader(string headerName)
        {
            return Request.Headers["Authorization"]
                          .ToString()
                          .Replace("Bearer ", "");
        }

        private Guid GetUserId()
        {
            return Guid.Parse(HttpContext.User.Identity.Name);
        }
    }
}
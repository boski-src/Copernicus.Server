using System.Threading.Tasks;
using AutoMapper;
using Copernicus.API.Dtos;
using Copernicus.Application.Identity.Queries;
using Copernicus.Common.Authentication;
using Copernicus.Common.CQRS;
using Copernicus.Core.Domain.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    [Auth]
    public class AccountController : BaseController
    {
        public AccountController(IMapper mapper, IDispatcher dispatcher) : base(mapper, dispatcher)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Object<User, AccountDto>(await Query(new GetAccount()));
        }
    }
}
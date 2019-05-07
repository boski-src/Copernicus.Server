using System;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Identity.Commands
{
    public class DestroySession : IAuthCommand
    {
        public Guid UserId { get; set; }
        public string BearerToken { get; set; }
    }
}
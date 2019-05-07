using System;

namespace Copernicus.Common.CQRS.Commands
{
    public interface IAuthCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
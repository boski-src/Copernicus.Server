using System;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Copernicus.Common.TaskExecutor
{
    public interface ITaskExecutor
    {
        ILogger<TaskExecutor> Logger { get; }
        TaskExecutor Init(Func<Task> action);
        TaskExecutor OnSuccess(Func<Task> action);
        TaskExecutor OnValidationError(Func<ValidationException, Task> action);
        TaskExecutor OnServiceError(Func<ServiceException, Task> action);

        TaskExecutor OnServiceError<TException>(Func<ServiceException, Task> action)
            where TException : ServiceException;

        TaskExecutor OnDomainError(Func<DomainException, Task> action);
        TaskExecutor OnUnknownError(Func<Exception, Task> action);
        TaskExecutor OnError(Func<Exception, Task> action);
        Task Build();
        Task BuildWithValidation<TInstance>(TInstance instance) where TInstance : class;
    }
}
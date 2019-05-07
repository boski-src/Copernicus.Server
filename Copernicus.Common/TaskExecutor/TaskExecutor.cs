using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Copernicus.Common.TaskExecutor
{
    public class TaskExecutor : ITaskExecutor
    {
        private readonly ILogger<TaskExecutor> _logger;
        private readonly IServiceProvider _serviceProvider;

        private IDictionary<Type, Func<ServiceException, Task>> _serviceExceptions =
            new Dictionary<Type, Func<ServiceException, Task>>();

        public ILogger<TaskExecutor> Logger => _logger;

        private Func<Task> _process = () => Task.CompletedTask;
        private Func<Task> _onSucceed = () => Task.CompletedTask;

        private Func<ValidationException, Task> _onValidationError = (ValidationException e) => Task.CompletedTask;
        private Func<ServiceException, Task> _onServiceError = (ServiceException e) => Task.CompletedTask;
        private Func<DomainException, Task> _onDomainError = (DomainException e) => Task.CompletedTask;
        private Func<Exception, Task> _onUnknownError = (Exception e) => Task.CompletedTask;
        private Func<Exception, Task> _onError = (Exception e) => Task.CompletedTask;

        public TaskExecutor(ILogger<TaskExecutor> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public TaskExecutor Init(Func<Task> action)
        {
            _process = action;
            return this;
        }

        public TaskExecutor OnSuccess(Func<Task> action)
        {
            _onSucceed = action;
            return this;
        }

        public TaskExecutor OnValidationError(Func<ValidationException, Task> action)
        {
            _onValidationError = action;
            return this;
        }

        public TaskExecutor OnServiceError(Func<ServiceException, Task> action)
        {
            _onServiceError = action;
            return this;
        }

        public TaskExecutor OnServiceError<TException>(Func<ServiceException, Task> action)
            where TException : ServiceException
        {
            _serviceExceptions.Add(typeof(TException), action);
            return this;
        }


        public TaskExecutor OnDomainError(Func<DomainException, Task> action)
        {
            _onDomainError = action;
            return this;
        }

        public TaskExecutor OnUnknownError(Func<Exception, Task> action)
        {
            _onUnknownError = action;
            return this;
        }

        public TaskExecutor OnError(Func<Exception, Task> action)
        {
            _onError = action;
            return this;
        }

        public async Task Build()
        {
            CheckMethodsImplemented();

            try
            {
                await _process();
                await _onSucceed();
            }
            catch (Exception exception)
            {
                await CallException(exception);
                await _onError(exception);
            }
        }

        public async Task BuildWithValidation<TInstance>(TInstance instance) where TInstance : class
        {
            CheckMethodsImplemented();

            try
            {
                var validator =
                    (AbstractValidator<TInstance>) _serviceProvider.GetService(typeof(AbstractValidator<TInstance>));
                if (validator != null)
                {
                    await validator.ValidateAndThrowAsync(instance);
                }

                await _process();
                await _onSucceed();
            }
            catch (Exception exception)
            {
                await CallException(exception);
                await _onError(exception);
            }
        }

        private void CheckMethodsImplemented()
        {
            if (_process == null)
            {
                throw new NotImplementedException("Task process method doesn't implemented.");
            }

            if (_onError == null)
            {
                _logger.LogWarning("OnError method doesn't implemented.");
            }
        }

        private async Task CallException(Exception exception)
        {
            switch (exception)
            {
                case ValidationException validationException:
                    await _onValidationError(validationException);
                    break;
                case ServiceException serviceException:
                    await serviceExceptionHandler(serviceException);
                    await _onServiceError(serviceException);
                    break;
                case DomainException domainException:
                    await _onDomainError(domainException);
                    break;
                default:
                    await _onUnknownError(exception);
                    break;
            }
        }

        private async Task serviceExceptionHandler(ServiceException exception)
        {
            var type = exception.GetType();
            if (_serviceExceptions.ContainsKey(type))
            {
                var serviceExceptionHandler = _serviceExceptions[type];
                await serviceExceptionHandler(exception);
            }
        }
    }
}
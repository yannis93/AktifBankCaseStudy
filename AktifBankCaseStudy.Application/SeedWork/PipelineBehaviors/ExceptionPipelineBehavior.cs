using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.SharedKernel.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.SeedWork.PipelineBehaviors
{
    public class ExceptionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public ExceptionPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (FluentValidation.ValidationException)
            {
                throw;
            }
            catch (DomainException)
            {
                throw;
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("----- An exception occured. Handling ExceptionPipelineBehavior. {RequestClassName}: {@Request}. {ResponseClassName}: {@Exception}", typeof(TRequest).Name, @request, typeof(TResponse).Name, ex);

                throw new UndefinedApplicationException(ex.Message, ex);
            }
        }
    }
}

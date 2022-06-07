using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.SeedWork.PipelineBehaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("----- Handling {ClassName} : {@Request}", typeof(TRequest).Name, @request);
            var response = await next();
            _logger.LogInformation("----- Handled {ClassName} : {@Response}", typeof(TResponse).Name, @response);
            return response;
        }
    }
}

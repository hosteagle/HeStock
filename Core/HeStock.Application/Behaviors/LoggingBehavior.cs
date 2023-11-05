using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeStock.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestNameWithGuid = $"{request.GetType().Name} [{Guid.NewGuid().ToString()}]";

            logger.LogInformation($"[START] {requestNameWithGuid}");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                LogRequestWithProps(request, requestNameWithGuid);

                return await next();
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation($"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
            }
        }

        private void LogRequestWithProps(TRequest request, string requestNameWithGuid)
        {
            try
            {
                logger.LogInformation($"[PROPS] {requestNameWithGuid} {JsonSerializer.Serialize(request)}");
            }
            catch (NotSupportedException)
            {
                logger.LogInformation($"[Serialization ERROR] {requestNameWithGuid} Could not serialize the request.");
            }
        }
    }
}

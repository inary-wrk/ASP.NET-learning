using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using MetricsAgent.Mediatr.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Mediatr.PipelineBehaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IMetricsGetQuery
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var id = Guid.NewGuid();
            Task<TResponse> response;
            _logger.LogInformation($"{id}|Processing metrics request for date time range:({request.DateTimeRange.From}) - ({request.DateTimeRange.To})");
            try
            {
                response = next();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Request id: ({id})");
                throw;
            }
            _logger.LogInformation($"{id}|The request is successful");
            return response;
        }
    }
}

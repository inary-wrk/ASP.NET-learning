using MediatR;
using System.Collections.Generic;
using MetricsAgent.Mediatr.Queries;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Models.Domain.Services;
using MetricsAgent.Models.Domain.Entities;
using Mapster;

namespace MetricsAgent.Mediatr.Handlers.Queries
{
    public class DotNetMetricsGetQueryHandler : RequestHandler<DotNetMetricsGetQuery, IReadOnlyCollection<DotNetMetricResponseDto>>
    {
        private readonly IMetricsRepository<DotNetMetric> _repository;

        public DotNetMetricsGetQueryHandler(IMetricsRepository<DotNetMetric> repository)
        {
            _repository = repository;
        }

        protected override IReadOnlyCollection<DotNetMetricResponseDto> Handle(DotNetMetricsGetQuery request)
        {
            var result = _repository.GetMetricsByTimePeriod(request.DateTimeRange.From, request.DateTimeRange.To);
            return result.Adapt<IReadOnlyCollection<DotNetMetricResponseDto>>();
        }
    }
}
using MediatR;
using System.Collections.Generic;
using MetricsAgent.Mediatr.Queries;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Models.Domain.Services;
using MetricsAgent.Models.Domain.Entities;
using Mapster;

namespace MetricsAgent.Mediatr.Handlers.Queries
{
    public class GetCPUMetricsQueryHandler : RequestHandler<GetCPUMetricsQuery, IReadOnlyCollection<CPUMetricResponseDto>>
    {
        private readonly IMetricsRepository<CPUMetric> _repository;

        public GetCPUMetricsQueryHandler(IMetricsRepository<CPUMetric> repository)
        {
            _repository = repository;
        }

        protected override IReadOnlyCollection<CPUMetricResponseDto> Handle(GetCPUMetricsQuery request)
        {
            var result = _repository.GetMetricsByTimePeriod(request.DateTimeRange.From, request.DateTimeRange.To);
            return result.Adapt<IReadOnlyCollection<CPUMetricResponseDto>>();
        }
    }
}
using MediatR;
using System.Collections.Generic;
using MetricsAgent.Mediatr.Queries;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Models.Domain.Services;
using MetricsAgent.Models.Domain.Entities;
using Mapster;
using System;

namespace MetricsAgent.Mediatr.Handlers.Queries
{
    public class CPUMetricsGetQueryHandler : RequestHandler<CPUMetricsGetQuery, IReadOnlyCollection<CPUMetricResponseDto>>
    {
        private readonly IMetricsQueryRepository<CPUMetric> _repository;

        public CPUMetricsGetQueryHandler(IMetricsQueryRepository<CPUMetric> repository)
        {
            _repository = repository;
        }

        protected override IReadOnlyCollection<CPUMetricResponseDto> Handle(CPUMetricsGetQuery request)
        {
            var result = _repository.GetMetricsByTimePeriod(request.DateTimeRange.From, request.DateTimeRange.To);
            return result.Adapt<IReadOnlyCollection<CPUMetricResponseDto>>();
        }
    }
}
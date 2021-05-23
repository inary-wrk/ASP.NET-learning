using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Mediatr.Queries;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;

namespace MetricsAgent.Mediatr.Handlers.Queries
{
    public class RAMMetricsGetQueryHandler : RequestHandler<RAMMetricsGetQuery, IReadOnlyCollection<RAMMetricResponseDto>>
    {
        private readonly IMetricsQueryRepository<RAMMetric> _repository;

        public RAMMetricsGetQueryHandler(IMetricsQueryRepository<RAMMetric> repository)
        {
            _repository = repository;
        }

        protected override IReadOnlyCollection<RAMMetricResponseDto> Handle(RAMMetricsGetQuery request)
        {
            var result = _repository.GetMetricsByTimePeriod(request.DateTimeRange.From, request.DateTimeRange.To);
            return result.Adapt<IReadOnlyCollection<RAMMetricResponseDto>>();
        }
    }
}

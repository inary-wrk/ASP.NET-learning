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
    public class NetworkMetricsGetQueryHandler : RequestHandler<NetworkMetricsGetQuery, IReadOnlyCollection<NetworkMetricResponseDto>>
    {
        private readonly IMetricsQueryRepository<NetworkMetric> _repository;

        public NetworkMetricsGetQueryHandler(IMetricsQueryRepository<NetworkMetric> repository)
        {
            _repository = repository;
        }

        protected override IReadOnlyCollection<NetworkMetricResponseDto> Handle(NetworkMetricsGetQuery request)
        {
            var result = _repository.GetMetricsByTimePeriod(request.DateTimeRange.From, request.DateTimeRange.To);
            return result.Adapt<IReadOnlyCollection<NetworkMetricResponseDto>>();
        }
    }
}

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
    public class HardDriveMetricsGetQueryHandler : RequestHandler<HardDriveMetricsGetQuery, IReadOnlyCollection<HardDriveMetricResponseDto>>
    {
        private readonly IMetricsRepository<HardDriveMetric> _repository;

        public HardDriveMetricsGetQueryHandler(IMetricsRepository<HardDriveMetric> repository)
        {
            _repository = repository;
        }

        protected override IReadOnlyCollection<HardDriveMetricResponseDto> Handle(HardDriveMetricsGetQuery request)
        {
            var result = _repository.GetMetricsByTimePeriod(request.DateTimeRange.From, request.DateTimeRange.To);
            return result.Adapt<IReadOnlyCollection<HardDriveMetricResponseDto>>();
        }
    }
}

using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Mediatr.Queries;
using MetricsAgent.Controllers.Dto;
using System.Threading;
using MetricsAgent.Models.Domain.Services;
using MetricsAgent.DAL.Models;

namespace MetricsAgent.Mediatr.Handlers
{
    public class GetCPUMetricsQueryHandler : RequestHandler<GetCPUMetricsQuery, IReadOnlyCollection<CPUMetricResponseDto>>
    {
        private readonly IMetricsQueryRepository<CPUMetricsDAL> _repository;

        public GetCPUMetricsQueryHandler(IMetricsQueryRepository<CPUMetricsDAL> repository)
        {
            _repository = repository;
        }

        protected override IReadOnlyCollection<CPUMetricResponseDto> Handle(GetCPUMetricsQuery request)
        {
            var result = _repository.GetMetricsByTimePeriod(request.DateTimeRange.From, request.DateTimeRange.To);
            return result;
        }
    }
}
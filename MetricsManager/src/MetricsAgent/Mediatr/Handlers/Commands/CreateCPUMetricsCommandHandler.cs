using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Mediatr.Commands;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;

namespace MetricsAgent.Mediatr.Handlers.Commands
{
    public class CreateCPUMetricsCommandHandler : RequestHandler<CreateCPUMetricCommand>
    {
        private readonly IMetricsRepository<CPUMetric> _repository;
        public CreateCPUMetricsCommandHandler(IMetricsRepository<CPUMetric> repository)
        {
            _repository = repository;
        }

        protected override void Handle(CreateCPUMetricCommand request)
        {
            _repository.Create(request.Metric);
        }
    }
}

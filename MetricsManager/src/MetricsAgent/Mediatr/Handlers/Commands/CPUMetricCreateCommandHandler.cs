using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Mediatr.Commands;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;

namespace MetricsAgent.Mediatr.Handlers.Commands
{
    public class CPUMetricCreateCommandHandler : AsyncRequestHandler<CPUMetricCreateCommand>
    {
        private readonly IMetricsCommandRepository<CPUMetric> _repository;
        public CPUMetricCreateCommandHandler(IMetricsCommandRepository<CPUMetric> repository)
        {
            _repository = repository;
        }


        protected override Task Handle(CPUMetricCreateCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateMetric(request.Metric);
            return Task.CompletedTask;
        }
    }
}

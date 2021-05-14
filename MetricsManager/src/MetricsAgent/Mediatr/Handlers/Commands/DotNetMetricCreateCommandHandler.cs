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
    public class DotNetMetricCreateCommandHandler : RequestHandler<DotNetMetricCreateCommand>
    {
        private readonly IMetricsRepository<DotNetMetric> _repository;
        public DotNetMetricCreateCommandHandler(IMetricsRepository<DotNetMetric> repository)
        {
            _repository = repository;
        }

        protected override void Handle(DotNetMetricCreateCommand request)
        {
            _repository.Create(request.Metric);
        }
    }
}

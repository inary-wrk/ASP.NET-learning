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
    public class RAMMetricCreateCommandHandler : RequestHandler<RAMMetricCreateCommand>
    {
        private readonly IMetricsRepository<RAMMetric> _repository;
        public RAMMetricCreateCommandHandler(IMetricsRepository<RAMMetric> repository)
        {
            _repository = repository;
        }
        protected override void Handle(RAMMetricCreateCommand request)
        {
            _repository.Create(request.Metric);
        }
    }
}

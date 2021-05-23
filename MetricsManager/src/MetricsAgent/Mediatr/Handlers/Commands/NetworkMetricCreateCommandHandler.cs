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
    public class NetworkMetricCreateCommandHandler : RequestHandler<NetworkMetricCreateCommand>
    {
        private readonly IMetricsCommandRepository<NetworkMetric> _repository;
        public NetworkMetricCreateCommandHandler(IMetricsCommandRepository<NetworkMetric> repository)
        {
            _repository = repository;
        }

        protected override void Handle(NetworkMetricCreateCommand request)
        {
            _repository.CreateMetric(request.Metric);
        }
    }
}

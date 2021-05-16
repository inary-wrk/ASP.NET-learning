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
    public class HardDriveMetricCreateCommandHandler : RequestHandler<HardDriveMetricCreateCommand>
    {
        private readonly IMetricsCommandRepository<HardDriveMetric> _repository;
        public HardDriveMetricCreateCommandHandler(IMetricsCommandRepository<HardDriveMetric> repository)
        {
            _repository = repository;
        }

        protected override void Handle(HardDriveMetricCreateCommand request)
        {
            _repository.CreateMetric(request.Metric);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Models.Domain.Entities;

namespace MetricsAgent.Mediatr.Commands
{
    public class HardDriveMetricCreateCommand : IRequest
    {
        public HardDriveMetric Metric { get; init; }

        public HardDriveMetricCreateCommand(HardDriveMetric metric)
        {
            Metric = metric;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Models.Domain.Entities;

namespace MetricsAgent.Mediatr.Commands
{
    public class NetworkMetricCreateCommand : IRequest
    {
        public NetworkMetric Metric { get; init; }

        public NetworkMetricCreateCommand(NetworkMetric metric)
        {
            Metric = metric;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Models.Domain.Entities;

namespace MetricsAgent.Mediatr.Commands
{
    public class DotNetMetricCreateCommand : IRequest
    {
        public DotNetMetric Metric { get; init; }

        public DotNetMetricCreateCommand(DotNetMetric metric)
        {
            Metric = metric;
        }
    }
}

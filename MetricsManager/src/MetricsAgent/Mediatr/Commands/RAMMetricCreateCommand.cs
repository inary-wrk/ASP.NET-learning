using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Models.Domain.Entities;

namespace MetricsAgent.Mediatr.Commands
{
    public class RAMMetricCreateCommand : IRequest
    {
        public RAMMetric Metric { get; init; }

        public RAMMetricCreateCommand(RAMMetric metric)
        {
            Metric = metric;
        }
    }
}

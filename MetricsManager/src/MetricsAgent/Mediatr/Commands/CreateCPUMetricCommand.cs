using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Models.Domain.Entities;

namespace MetricsAgent.Mediatr.Commands
{
    public class CreateCPUMetricCommand : IRequest
    {
        public CPUMetric Metric { get; init; }

        public CreateCPUMetricCommand(CPUMetric metric)
        {
            Metric = metric;
        }
    }
}

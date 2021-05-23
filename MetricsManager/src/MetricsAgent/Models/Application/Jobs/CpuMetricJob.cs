using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MetricsAgent.Mediatr.Commands;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Quartz;

namespace MetricsAgent.Models.Application.Jobs
{
    [DisallowConcurrentExecution]
    public class CpuMetricJob : IJob
    {
        private readonly IMediator _mediator;
        private PerformanceCounter _cpuCounter;
        private readonly IDateTimeProvider _dateTimeProvider;


        public CpuMetricJob(IMediator mediator, IDateTimeProvider dateTimeProvider)
        {
            _mediator = mediator;
            _dateTimeProvider = dateTimeProvider;
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var cpuUsage = Convert.ToInt32(_cpuCounter.NextValue());
            Console.WriteLine("job start");
            var command = new CPUMetricCreateCommand(
                new CPUMetric()
                {
                    DateTime = _dateTimeProvider.UtcNow,
                    CpuUsage = cpuUsage
                });

          await _mediator.Send(command);
            
            //return Task.CompletedTask;
        }
    }
}

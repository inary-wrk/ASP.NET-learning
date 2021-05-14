using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using MediatR;
using MetricsAgent.Mediatr.Commands;
using MetricsAgent.Models.Domain.Entities;

namespace MetricsAgent.DAL.Configuration
{
    public class FillDataBase
    {
        private readonly IMediator _mediator;
        const int COUNT = 10;
        const int SEED = 341124;

        public FillDataBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void FillMetricsDataBase()
        {
            Randomizer.Seed = new(SEED);
            for (int i = 0; i < COUNT; i++)
            {
                var cpumetric = new Faker<CPUMetric>()
                    .RuleFor(x => x.DateTime, x =>
                    x.Date.BetweenOffset(DateTimeOffset.UnixEpoch, DateTimeOffset.MaxValue))
                    .RuleFor(x => x.Something, x => x.Random.Int())
                    .Generate();
                var command = new CreateCPUMetricCommand(cpumetric);
                _mediator.Send(command);
            }
        }
    }
}

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
        private readonly DateTimeOffset _from = DateTimeOffset.Parse("2019-01-01");
        private readonly DateTimeOffset _to = DateTimeOffset.Parse("2021-01-01");


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
                    .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(_from, _to))
                    .RuleFor(x => x.Something, x => x.Random.Int(10, 85))
                    .Generate();
                var commandcpu = new CPUMetricCreateCommand(cpumetric);
                _mediator.Send(commandcpu);

                var dotnetmetric = new Faker<DotNetMetric>()
                    .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(_from, _to))
                    .RuleFor(x => x.Something, x => x.Hacker.Phrase())
                    .Generate();
                var commanddotnet = new DotNetMetricCreateCommand(dotnetmetric);
                _mediator.Send(commanddotnet);

                var harddrivemetric = new Faker<HardDriveMetric>()
                    .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(_from, _to))
                    .RuleFor(x => x.Something, x => x.Random.Int(0))
                    .Generate();
                var commandharddrive = new HardDriveMetricCreateCommand(harddrivemetric);
                _mediator.Send(commandharddrive);

                var networkmetric = new Faker<NetworkMetric>()
                    .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(_from, _to))
                    .RuleFor(x => x.Something, x => x.Random.Int(0, 209715200))
                    .Generate();
                var commandnetwork = new NetworkMetricCreateCommand(networkmetric);
                _mediator.Send(commandnetwork);

                var rammetric = new Faker<RAMMetric>()
                    .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(_from, _to))
                    .RuleFor(x => x.Something, x => x.Random.Int(0))
                    .Generate();
                var commandram = new RAMMetricCreateCommand(rammetric);
                _mediator.Send(commandram);

            }
        }
    }
}

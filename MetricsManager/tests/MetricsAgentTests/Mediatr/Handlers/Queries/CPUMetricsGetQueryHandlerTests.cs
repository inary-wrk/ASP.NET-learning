using Xunit;
using MetricsAgent.Mediatr.Handlers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models.Domain.Services;
using MetricsAgent.Models.Domain.Entities;
using NSubstitute;
using AutoBogus;
using MetricsAgent.Controllers.Dto;
using MediatR;
using MetricsAgent.Mediatr.Queries;
using Mapster;
using System.Collections.ObjectModel;
using FluentAssertions;

namespace MetricsAgent.Mediatr.Handlers.Queries.Tests
{
    public class CPUMetricsGetQueryHandlerTests : CPUMetricsGetQueryHandler
    {
        private static readonly IMetricsQueryRepository<CPUMetric> _repository = Substitute.For<IMetricsQueryRepository<CPUMetric>>();

        public CPUMetricsGetQueryHandlerTests() : base(_repository)
        {

        }

        [Fact()]
        public void CPUMetricsGetQueryHandlerTest()
        {
            //Arrange
            var dateTimeRange = new AutoFaker<DateTimeRangeRequestDto>()
                .RuleFor(x => x.From, f => f.Date.RecentOffset(5))
                .RuleFor(x => x.To, f => f.Date.SoonOffset(5))
                .Generate();

            IReadOnlyCollection<CPUMetric> metricsList = new AutoFaker<CPUMetric>()
                .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(dateTimeRange.From, dateTimeRange.To))
                .RuleFor(x => x.CpuUsage, x => x.Random.Int(35, 95))
                .Generate(4).ToList();
            var expected = metricsList.Adapt<IReadOnlyCollection<CPUMetricResponseDto>>();

            _repository.GetMetricsByTimePeriod(Arg.Any<DateTimeOffset>(), Arg.Any<DateTimeOffset>()).Returns(metricsList);
            var query = new CPUMetricsGetQuery(dateTimeRange);

            //Act
            var resultMetricsList = base.Handle(query);

            //Assert
            _repository.Received(1).GetMetricsByTimePeriod(dateTimeRange.From, dateTimeRange.To);
            resultMetricsList.Should().BeEquivalentTo(expected);
        }
    }
}
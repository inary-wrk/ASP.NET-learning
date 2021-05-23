using Xunit;
using MetricsAgent.Mediatr.Handlers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBogus;
using Mapster;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Mediatr.Queries;
using MetricsAgent.Models.Domain.Entities;
using NSubstitute;
using MetricsAgent.Models.Domain.Services;
using FluentAssertions;

namespace MetricsAgent.Mediatr.Handlers.Queries.Tests
{
    public class RAMMetricsGetQueryHandlerTests:RAMMetricsGetQueryHandler
    {
        private static readonly IMetricsQueryRepository<RAMMetric> _repository = Substitute.For<IMetricsQueryRepository<RAMMetric>>();

        public RAMMetricsGetQueryHandlerTests() : base(_repository)
        {

        }

        [Fact()]
        public void RAMMetricsGetQueryHandlerTest()
        {
            //Arrange
            var dateTimeRange = new AutoFaker<DateTimeRangeRequestDto>()
                .RuleFor(x => x.From, f => f.Date.RecentOffset(5))
                .RuleFor(x => x.To, f => f.Date.SoonOffset(5))
                .Generate();

            IReadOnlyCollection<RAMMetric> metricsList = new AutoFaker<RAMMetric>()
                .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(dateTimeRange.From, dateTimeRange.To))
                .RuleFor(x => x.Something, x => x.Random.Int(0, 209715200))
                .Generate(4).ToList();
            var expected = metricsList.Adapt<IReadOnlyCollection<RAMMetricResponseDto>>();

            _repository.GetMetricsByTimePeriod(Arg.Any<DateTimeOffset>(), Arg.Any<DateTimeOffset>()).Returns(metricsList);
            var query = new RAMMetricsGetQuery(dateTimeRange);

            //Act
            var resultMetricsList = base.Handle(query);

            //Assert
            _repository.Received(1).GetMetricsByTimePeriod(dateTimeRange.From, dateTimeRange.To);
            resultMetricsList.Should().BeEquivalentTo(expected);
        }
    }
}
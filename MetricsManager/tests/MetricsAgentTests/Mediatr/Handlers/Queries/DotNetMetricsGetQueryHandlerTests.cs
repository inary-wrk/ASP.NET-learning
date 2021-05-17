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
    public class DotNetMetricsGetQueryHandlerTests : DotNetMetricsGetQueryHandler
    {
        private static readonly IMetricsQueryRepository<DotNetMetric> _repository = Substitute.For<IMetricsQueryRepository<DotNetMetric>>();

        public DotNetMetricsGetQueryHandlerTests() : base(_repository)
        {

        }

        [Fact()]
        public void DotNetMetricsGetQueryHandlerTest()
        {
            //Arrange
            var dateTimeRange = new AutoFaker<DateTimeRangeRequestDto>()
                .RuleFor(x => x.From, f => f.Date.RecentOffset(5))
                .RuleFor(x => x.To, f => f.Date.SoonOffset(5))
                .Generate();

            IReadOnlyCollection<DotNetMetric> metricsList = new AutoFaker<DotNetMetric>()
                .RuleFor(x => x.DateTime, x => x.Date.BetweenOffset(dateTimeRange.From, dateTimeRange.To))
                .RuleFor(x => x.Something, x => x.Hacker.Phrase())
                .Generate(4).ToList();
            var expected = metricsList.Adapt<IReadOnlyCollection<DotNetMetricResponseDto>>();

            _repository.GetMetricsByTimePeriod(Arg.Any<DateTimeOffset>(), Arg.Any<DateTimeOffset>()).Returns(metricsList);
            var query = new DotNetMetricsGetQuery(dateTimeRange);

            //Act
            var resultMetricsList = base.Handle(query);

            //Assert
            _repository.Received(1).GetMetricsByTimePeriod(dateTimeRange.From, dateTimeRange.To);
            resultMetricsList.Should().BeEquivalentTo(expected);
        }
    }
}

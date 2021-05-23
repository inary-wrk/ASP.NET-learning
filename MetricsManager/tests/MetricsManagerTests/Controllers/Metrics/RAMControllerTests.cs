using Xunit;
using MetricsManager.Controllers.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MetricsManager.Dto;

namespace MetricsManager.Controllers.Metrics.Tests
{
    public class RAMControllerTests
    {
        private readonly RAMController _controller;

        public RAMControllerTests()
        {
            _controller = new RAMController();
        }

        [Fact()]
        public void GetMetricsFromAgentTest()
        {
            DateTimeRangeDto dateTimeRange = new()
            {
                From = DateTimeOffset.Parse("27/04/2021"),
                To = DateTimeOffset.Parse("20/05/2021")
            };
            AgentIdRequestDto agentId = new() { Id = Guid.NewGuid().ToString() };

            var result = _controller.GetMetricsFromAgent(agentId, dateTimeRange);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact()]
        public void GetMetricsFromClusterTest()
        {
            DateTimeRangeDto dateTimeRange = new()
            {
                From = DateTimeOffset.Parse("27/04/2021"),
                To = DateTimeOffset.Parse("20/05/2021")
            };

            var result = _controller.GetMetricsFromCluster(dateTimeRange);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
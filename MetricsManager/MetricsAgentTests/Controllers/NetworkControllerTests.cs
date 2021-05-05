using Xunit;
using MetricsAgent.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers.Tests
{
    public class NetworkControllerTests
    {
        private readonly NetworkController _controller;

        public NetworkControllerTests()
        {
            _controller = new NetworkController();
        }

        [Fact()]
        public void GetTest()
        {
            DateTimeRangeDto dateTimeRange = new();
            dateTimeRange.From = DateTimeOffset.Parse("27/04/2021");
            dateTimeRange.To = DateTimeOffset.Parse("20/05/2021");

            var result = _controller.Get(dateTimeRange);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
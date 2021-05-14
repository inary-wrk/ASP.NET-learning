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
    public class DotNetControllerTests
    {
        private readonly DotNetController _controller;

        public DotNetControllerTests()
        {
            _controller = new DotNetController();
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
using Xunit;
using MetricsAgent.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Controllers.Tests
{
    public class CPUControllerTests
    {
        private readonly CPUController _controller;

        public CPUControllerTests()
        {
            _controller = new CPUController();
        }

        [Fact()]
        public void GetTest()
        {
            DateTimeRangeRequestDto dateTimeRange = new ();
            dateTimeRange.From = DateTimeOffset.Parse("27/04/2021");
            dateTimeRange.To = DateTimeOffset.Parse("20/05/2021");

            var result = _controller.GetCPUMetrics(dateTimeRange);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
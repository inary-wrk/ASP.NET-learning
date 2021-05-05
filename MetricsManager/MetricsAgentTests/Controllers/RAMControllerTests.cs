using Xunit;
using MetricsAgent.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers.Tests
{
    public class RAMControllerTests
    {
        private readonly RAMController _controller;

        public RAMControllerTests()
        {
            _controller = new RAMController();
        }

        [Fact()]
        public void GetTest()
        {
            var result = _controller.Get();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
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
    public class HardDriveControllerTests
    {
        private readonly HardDriveController _controller;

        public HardDriveControllerTests()
        {
            _controller = new HardDriveController();
        }
        [Fact()]
        public void GetTest()
        {
            throw new NotImplementedException();
           // var result = _controller.Get();

           // _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
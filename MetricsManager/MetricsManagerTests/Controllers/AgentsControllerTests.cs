using Xunit;
using MetricsManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers.Tests
{
    public class AgentsControllerTests
    {
        private readonly AgentsController _controller;

        public AgentsControllerTests()
        {
            _controller = new AgentsController();
        }

        [Fact()]
        public void RegisterTest()
        {
            AgentInfoRequestDto agentInfo = new()
            {
                Id = Guid.NewGuid().ToString(),
                Address = new Uri("http://localhost:26844/api/hdd")
            };

            var result = _controller.Register(agentInfo);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact()]
        public void GetAgentsListTest()
        {
            var result = _controller.GetAgentsList();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact()]
        public void DisableAgentTest()
        {
            AgentIdRequestDto agentId = new() { Id = Guid.NewGuid().ToString() };

            var result = _controller.DisableAgent(agentId);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact()]
        public void EnableAgentTest()
        {
            AgentIdRequestDto agentId = new() { Id = Guid.NewGuid().ToString() };

            var result = _controller.DisableAgent(agentId);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
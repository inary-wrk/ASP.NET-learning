﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/hdd")]
    [ApiController]
    public class HardDriveController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
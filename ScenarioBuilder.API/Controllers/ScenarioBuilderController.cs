using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheTaleOfU.NetCore.Shared;

namespace ScenarioBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioBuilderController : ControllerBase
    {

        [HttpPost, Route("save")]
        public void PostScenarios(List<ScenarioOptionTransferObject> Scenarios)
        {

        }


        [HttpGet, Route("test")]
        public void TestStringReceieved(string testString)
        {
            var strings = "er";
            strings += testString;
        }
    }
}
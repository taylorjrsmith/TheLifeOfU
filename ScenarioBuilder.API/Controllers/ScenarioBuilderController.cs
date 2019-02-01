using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheTaleOfU.NetCore.EntityLayer;
using TheTaleOfU.NetCore.ServiceLayer;
using TheTaleOfU.NetCore.Shared;

namespace ScenarioBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioBuilderController : ControllerBase
    {
        public IScenarioProcessor ScenarioProcessor { get; set; }
        public IOptionProcessor OptionProcessor { get; set; }

        public ScenarioBuilderController(IScenarioProcessor scenarioProcessor, IOptionProcessor optionProcessor)
        {
            ScenarioProcessor = scenarioProcessor;
            OptionProcessor = optionProcessor;
        }

        [HttpPost, Route("save")]
        public IActionResult PostScenarios([FromBody] List<ScenarioTransferObject> scenarios)
        {
            List<Scenario> Scenarios = new List<Scenario>();

            foreach (var s in scenarios)
            {
                ScenarioProcessor.CreateScenario(s, OptionProcessor);
            }
            ScenarioProcessor.CommitScenarios();

            return new OkResult();
        }


        [HttpGet, Route("test")]
        public void TestStringReceieved(string testString)
        {
            var strings = "er";
            strings += testString;
        }
    }
}
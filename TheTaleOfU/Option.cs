using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int OriginScenarioId { get; set; }
        public Scenario OriginScenario { get; set; }
        public int NextScenarioId { get; set; }
        public Scenario NextScenario { get; set; }
        public int OptionIdentifier { get; set; }

    }
}

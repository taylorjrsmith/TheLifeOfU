using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? OriginScenarioId { get; set; }
        [ForeignKey("OriginScenarioId")]
        public Scenario OriginScenario { get; set; }
        public int? NextScenarioId { get; set; }
        [ForeignKey("NextScenarioId")]
        public Scenario NextScenario { get; set; }
        public int OptionIdentifier { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU.NetCore.EntityLayer
{
    public class Option
    {
        [Column("OptionId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int OriginScenarioId { get; set; }
        [ForeignKey("OriginScenarioId")]
        public virtual Scenario OriginScenario { get; set; }
        [NotMapped]
        public string NextScenarioName { get; set; }
        public int? NextScenarioId { get; set; }
        [ForeignKey("NextScenarioId")]
        public virtual Scenario NextScenario { get; set; }
        public int OptionIdentifier { get; set; }
        public List<GainItemEvent> GainItemEvents { get; set; }

    }
}

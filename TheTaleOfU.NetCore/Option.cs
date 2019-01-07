using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TheTaleOfU.NetCore.EntityLayer.Events;

namespace TheTaleOfU.NetCore.EntityLayer
{
   public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? NextScenarioId { get; set; }
        [ForeignKey("NextScenarioId")]
        public virtual Scenario NextScenario { get; set; }
        public int OptionIdentifier { get; set; }
        public List<GainItemEvent> GainItemEvents { get; set; }

    }
}

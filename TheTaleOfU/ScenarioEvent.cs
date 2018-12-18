using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU
{
    public class ScenarioEvent
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int OriginScenarioId { get; set; }
        public virtual Item LinkedItem { get; set; }
    }
}

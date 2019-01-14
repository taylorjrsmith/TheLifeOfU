using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU
{
    public class GainItemEvent
    {
        [Column("GainItemEventId")]
        public int Id { get; set; }
        public string CustomText { get; set; }
        public Item Item { get; set; }
        [NotMapped]
        public Player CurrentPlayer { get; set; }
        public int OptionId { get; set; }
        [ForeignKey("OptionId")]
        public virtual Option Option { get; set; }

    }
}

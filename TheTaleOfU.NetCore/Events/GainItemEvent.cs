using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheTaleOfU.NetCore.EntityLayer.Events
{
    public class GainItemEvent
    {
        public int Id { get; set; }
        public string CustomText { get; set; }
        public Item Item { get; set; }
        [NotMapped]
        public Player CurrentPlayer { get; set; }
        public int OptionId { get; set; }
        [ForeignKey("OptionId")]
        public Option Option { get; set; }
    }
}

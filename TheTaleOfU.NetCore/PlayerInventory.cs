using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU.NetCore.EntityLayer
{
    public class PlayerInventory
    {
        [Column("PlayerInventoryId")]
        public int Id { get; set; }
        public Guid PlayerGuid { get; set; }
        [ForeignKey("PlayerGuid")]
        public virtual Player Player { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}

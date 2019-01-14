using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTaleOfU.Enums;

namespace TheTaleOfU
{
    public class Player
    {
        [Column("PlayerGuid")]
        public Guid Id { get; set; }
        public int Health { get; set; }
        public string Name { get; set; }
        public virtual List<PlayerInventory> Inventory { get; set; }
        public PlayerType PlayerType { get; set; }
        [NotMapped]
        public Item ActiveItem { get; set; }
    }
}

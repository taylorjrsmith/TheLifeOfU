using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TheTaleOfU.NetCore.EntityLayer.Enums;

namespace TheTaleOfU.NetCore.EntityLayer
{
    public class Player
    {
        public int Id { get; set; }
        public int Health { get; set; }
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }
        public PlayerType PlayerType { get; set; }
        [NotMapped]
        public Item ActiveItem { get; set; }
    }
}

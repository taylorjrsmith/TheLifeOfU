using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTaleOfU.NetCore.EntityLayer.Enums;

namespace TheTaleOfU.NetCore.EntityLayer
{
    public class Item
    {
        [Column("ItemId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Durability is the number of uses an item has
        /// </summary>
        public int Durability { get; set; }
        public int Rarity { get; set; }
    }
}

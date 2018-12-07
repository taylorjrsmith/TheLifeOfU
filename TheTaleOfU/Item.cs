using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTaleOfU.Enums;

namespace TheTaleOfU
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Damage { get; set; }
        public string Effect { get; set; }
        /// <summary>
        /// Durability is the number of uses an item has
        /// </summary>
        public int Durability { get; set; }
    }
}

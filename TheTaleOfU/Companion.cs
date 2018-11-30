using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTaleOfU.Enums;

namespace TheTaleOfU
{
    public class Companion
    {
        public int Id { get; set; }
        public CompanionType CompanionType { get; set; }
        public List<Item> Inventory { get; set; }
    }
}

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
        public int Id { get; set; }
        public string CustomText { get; set; }
        public Item Item { get; set; }
        [NotMapped]
        public Player CurrentPlayer { get; set; }
        public int OptionId { get; set; }
        [ForeignKey("OptionId")]
        public Option Option { get; set; }

        public void Run()
        {
            Console.WriteLine(CustomText);
            Console.WriteLine("Press C to continue");
            Console.ReadKey();
            CurrentPlayer.Inventory.Add(Item);
        }

    }
}

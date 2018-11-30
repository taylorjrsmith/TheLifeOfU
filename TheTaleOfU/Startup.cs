using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU
{
    public class GameEngine
    {
        public List<Player> Players { get; set; }

        public void StartGame()
        {
            Console.WriteLine("Welcome to TheLifeOfU");
            Console.WriteLine("How many of you are playing?");
            var isValid = false;
            int playerCountNumeric = 0;
            while (isValid)
            {
                var playerCount = Console.ReadLine();
                isValid = ValidatePlayerCount(playerCount);
                if (isValid)
                    playerCountNumeric = Convert.ToInt32(playerCount);
            }

            for (int i = 0; i < playerCountNumeric; i++)
            {
                var player = new Player();
                player.Health = 100;
                var name = Console.ReadLine();
                player.Name = name;
                player.Inventory = new List<Item>();
            }

        }

        public bool ValidatePlayerCount(string playerCount)
        {
            var isValidNumber = int.TryParse(playerCount, out int numericCount);

            return isValidNumber;
        }
    }
}

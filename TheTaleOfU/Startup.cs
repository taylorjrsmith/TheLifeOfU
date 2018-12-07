using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTaleOfU.Enums;

namespace TheTaleOfU
{
    public class GameEngine
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public void StartGame()
        {
            Console.WriteLine("Welcome to TheLifeOfU");
            Console.WriteLine("How many of you are playing?");
            var isValid = false;
            int playerCountNumeric = 0;
            while (!isValid)
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
                Console.WriteLine($"Player {i}, what is your name?");
                var name = Console.ReadLine();
                player.Name = name;
                player.Inventory = new List<Item>();
                GeneratePlayerType(player);
                Console.WriteLine($"Welcome to TheLifeOfU {player.Name}, I have assigned you as a {player.PlayerType}, Press any key to continue");
                Console.ReadKey();
                Players.Add(player);

            }

            Console.WriteLine("This round of TheLifeOfU will last 1 hour, you now have 1 hour to earn as much money as you can not die and run through different scenarios, good luck");
            var hourWindow = DateTime.Now.AddHours(1);

            while (hourWindow > DateTime.Now)
            {
                var scenario = LoadScenario();
                scenario.RunScenario();
            }


        }

        public Scenario LoadScenario()
        {
            using (var scenarioContext = new TheTaleOfUContext())
            {
                var numberOfScenarios = scenarioContext.Scenarios.Count();

                var scenario = scenarioContext.Scenarios.FirstOrDefault();
                var options = scenarioContext.Options.Where(a => a.OriginScenarioId == scenario.Id);
                scenario.Options = options.ToList();
                return scenario;
            }
        }

        public void GeneratePlayerType(Player player)
        {
            var enums = Enum.GetValues(typeof(PlayerType));
            var numberOfPlayerTypes = enums.Length;
            var randomNumber = new Random().Next(1, numberOfPlayerTypes);
            var playerType = enums.GetValue(randomNumber);
            player.PlayerType = (PlayerType)playerType;
        }

        public bool ValidatePlayerCount(string playerCount)
        {
            var isValidNumber = int.TryParse(playerCount, out int numericCount);

            return isValidNumber;
        }
    }
}

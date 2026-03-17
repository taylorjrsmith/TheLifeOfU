using TheTaleOfU.Enums;

namespace TheTaleOfU;

public class GameEngine
{
    private readonly TheTaleOfUContext _context;
    public List<Player> Players { get; set; } = new();

    public GameEngine(TheTaleOfUContext context)
    {
        _context = context;
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to TheLifeOfU");
        Console.WriteLine("How many of you are playing?");

        int playerCountNumeric = 0;
        bool isValid = false;
        while (!isValid)
        {
            var playerCount = Console.ReadLine();
            isValid = ValidatePlayerCount(playerCount, out playerCountNumeric);
        }

        for (int i = 0; i < playerCountNumeric; i++)
        {
            var player = new Player { Health = 100, Inventory = new List<Item>() };
            Console.WriteLine($"Player {i + 1}, what is your name?");
            player.Name = Console.ReadLine() ?? $"Player {i + 1}";
            GeneratePlayerType(player);
            Console.WriteLine($"Welcome to TheLifeOfU {player.Name}, you have been assigned as a {player.PlayerType}. Press any key to continue.");
            Console.ReadKey();
            Players.Add(player);
        }

        Console.WriteLine("This round of TheLifeOfU will last 1 hour. Earn as much as you can, don't die, and run through as many scenarios as possible. Good luck!");
        var hourWindow = DateTime.Now.AddHours(1);

        while (hourWindow > DateTime.Now)
        {
            foreach (var p in Players)
            {
                Console.WriteLine($"{p.Name}, it's your turn.");
                var scenario = LoadScenario();
                if (scenario is null)
                {
                    Console.WriteLine("No scenarios found in the database.");
                    return;
                }
                scenario.RunScenario(p, _context);
            }
        }
    }

    public Scenario? LoadScenario()
    {
        var scenario = _context.Scenarios.FirstOrDefault();
        if (scenario is null) return null;
        scenario.Options = _context.Options.Where(a => a.OriginScenarioId == scenario.Id).ToList();
        return scenario;
    }

    public void GeneratePlayerType(Player player)
    {
        var values = Enum.GetValues<PlayerType>();
        player.PlayerType = values[new Random().Next(0, values.Length)];
    }

    public bool ValidatePlayerCount(string? input, out int count)
    {
        return int.TryParse(input, out count) && count > 0;
    }
}

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TheTaleOfU.Enums;

namespace TheTaleOfU;

public class Scenario
{
    public int Id { get; set; }
    public string ScenarioDescription { get; set; } = string.Empty;
    public PlayerType AllowedPlayerTypes { get; set; }
    public List<Option> Options { get; set; } = new();
    public bool IsEndOfScenarioRoute { get; set; }
    public string? EndOfEventMethodName { get; set; }

    public bool HasEvent => !string.IsNullOrEmpty(EndOfEventMethodName);

    private Player? CurrentPlayer { get; set; }

    /// <summary>
    /// The event that can be triggered at the end of this scenario (gain item, take damage, etc.)
    /// </summary>
    public virtual ScenarioEvent? Event { get; set; }

    public void RunScenario(Player player, TheTaleOfUContext context)
    {
        CurrentPlayer = player;
        Console.WriteLine(ScenarioDescription);

        if (IsEndOfScenarioRoute || HasEvent)
        {
            Event = context.Events.Include(e => e.LinkedItem)
                                  .FirstOrDefault(a => a.OriginScenarioId == Id);
            if (Event is not null && EndOfEventMethodName is not null)
                CallEventFromString(EndOfEventMethodName);
        }

        if (Options.Count == 0)
            Options = context.Options.Where(a => a.OriginScenarioId == Id).ToList();

        if (Options.Count == 0 || IsEndOfScenarioRoute)
        {
            Console.WriteLine("--- End of scenario route ---");
            Console.ReadKey();
            return;
        }

        Console.ReadKey();
        foreach (var o in Options)
            Console.WriteLine($"{o.OptionIdentifier} : {o.Text}");

        string? option;
        bool wasValidOption = false;
        while (!wasValidOption)
        {
            option = Console.ReadLine();
            wasValidOption = ProcessOption(option);
            if (!wasValidOption)
                Console.WriteLine("Please enter a valid option number.");
        }

        option = Console.ReadLine();
        var numericOption = Convert.ToInt32(option);
        var nextOption = Options.First(a => a.OptionIdentifier == numericOption);
        var nextScenario = context.Scenarios.FirstOrDefault(a => a.Id == nextOption.NextScenarioId);
        if (nextScenario is null) return;

        nextOption.NextScenario = nextScenario;
        nextOption.NextScenario.RunScenario(player, context);
    }

    public bool ProcessOption(string? selectedOption)
    {
        if (!int.TryParse(selectedOption?.Trim(), out int parsed)) return false;
        return Options.Any(a => a.OptionIdentifier == parsed);
    }

    public void CallEventFromString(string eventName)
    {
        var mi = GetType().GetMethod(eventName);
        mi?.Invoke(this, null);
    }

    public void UseAnItem()
    {
        if (CurrentPlayer?.ActiveItem is null) return;
        if (CurrentPlayer.ActiveItem.Durability > 0)
            CurrentPlayer.ActiveItem.Durability--;
        if (CurrentPlayer.ActiveItem.Durability == 0)
            CurrentPlayer.Inventory.Remove(CurrentPlayer.ActiveItem);
    }

    public void GainItem()
    {
        if (Event?.LinkedItem is not null)
            CurrentPlayer?.Inventory.Add(Event.LinkedItem);
    }

    public void TakeDamage()
    {
        if (CurrentPlayer is not null && Event?.LinkedItem is not null)
            CurrentPlayer.Health -= Event.LinkedItem.Value;
    }

    public void HealthGain()
    {
        if (CurrentPlayer is not null && Event?.LinkedItem is not null)
        {
            CurrentPlayer.Health += Event.LinkedItem.Value;
            Console.WriteLine($"Congratulations {CurrentPlayer.Name}, you gained {Event.LinkedItem.Value} health from using a {Event.LinkedItem.Name}!");
        }
    }
}

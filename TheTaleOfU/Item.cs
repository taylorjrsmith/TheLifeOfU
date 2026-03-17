using TheTaleOfU.Enums;

namespace TheTaleOfU;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ItemType Type { get; set; }
    public int Damage { get; set; }
    public string? Effect { get; set; }
    /// <summary>Number of uses remaining.</summary>
    public int Durability { get; set; }
    public int Value { get; set; }
}

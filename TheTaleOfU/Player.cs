using System.ComponentModel.DataAnnotations.Schema;

namespace TheTaleOfU;

public class Player
{
    public int Id { get; set; }
    public int Health { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Item> Inventory { get; set; } = new();
    public PlayerType PlayerType { get; set; }
    [NotMapped]
    public Item? ActiveItem { get; set; }
}

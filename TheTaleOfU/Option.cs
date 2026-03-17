using System.ComponentModel.DataAnnotations.Schema;

namespace TheTaleOfU;

public class Option
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int OriginScenarioId { get; set; }
    [ForeignKey("OriginScenarioId")]
    public Scenario OriginScenario { get; set; } = null!;
    public int? NextScenarioId { get; set; }
    [ForeignKey("NextScenarioId")]
    public virtual Scenario? NextScenario { get; set; }
    public int OptionIdentifier { get; set; }
}

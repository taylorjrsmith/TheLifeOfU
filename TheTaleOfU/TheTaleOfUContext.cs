using Microsoft.EntityFrameworkCore;

namespace TheTaleOfU;

public class TheTaleOfUContext : DbContext
{
    public DbSet<Scenario> Scenarios { get; set; } = null!;
    public DbSet<Option> Options { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<ScenarioEvent> Events { get; set; } = null!;

    public TheTaleOfUContext(DbContextOptions<TheTaleOfUContext> options) : base(options)
    {
    }

    // Parameterless constructor for design-time tooling (migrations)
    public TheTaleOfUContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:TheTaleOfUContext");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Option>()
            .HasOne(o => o.OriginScenario)
            .WithMany(s => s.Options)
            .HasForeignKey(o => o.OriginScenarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Option>()
            .HasOne(o => o.NextScenario)
            .WithMany()
            .HasForeignKey(o => o.NextScenarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

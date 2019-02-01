using Microsoft.EntityFrameworkCore;
using System;
using TheTaleOfU.NetCore.EntityLayer;

namespace TheTaleOfU.NetCore.DataLayer
{
    public class TheTaleOfUContext : DbContext
    {

        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PlayerInventory> Inventories { get; set; }
        public DbSet<GainItemEvent> GainItemEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=TheTaleOfU;Integrated Security=True;Pooling=False;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>().HasOne(o => o.NextScenario);
            modelBuilder.Entity<Scenario>().HasMany(s => s.Options).WithOne(a => a.OriginScenario);
            modelBuilder.Entity<PlayerInventory>().HasKey(a => a.Id);


        }

    }
}

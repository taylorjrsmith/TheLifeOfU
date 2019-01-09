using Microsoft.EntityFrameworkCore;
using System;
using TheTaleOfU.NetCore.EntityLayer;

namespace TheTaleOfU.NetCore.DataLayer
{
    public class TheTaleOfUContext : DbContext
    {

        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Item> Item { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MYBITCH\SQLEXPRESS;Initial Catalog=TheTaleOfU;Integrated Security=True;Pooling=False;Connect Timeout=30");
        }

    }
}

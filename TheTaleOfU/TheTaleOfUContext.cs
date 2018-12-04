using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTaleOfU
{
    public class TheTaleOfUContext : DbContext
    {
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Item> Items { get; set; }
        public TheTaleOfUContext() : base("TheTaleOfUContext")
        {
                
        }

    }
}

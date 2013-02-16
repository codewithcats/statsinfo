using System.Data.Entity;

namespace StatsInfoSystem
{
    class StsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace StatsInfoSystem
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(d => d.Code).IsRequired();
        }
    }
}

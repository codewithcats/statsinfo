
namespace StatsInfoSystem
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName
        {
            get
            {
                return "[" + this.Code + "] " + this.Name;
            }
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }
        public ProductGroup group { get; set; }
    }
}

using StatsInfoSystem;

namespace StsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertProductGroup();
        }

        private static void InsertProductGroup()
        {
            var group = new ProductGroup
            {
                Code = "PG01",
                Name = "Wooden Salad Bowl & Servers"
            };
            using (var context = new StsContext())
            {
                context.ProductGroups.Add(group);
                context.SaveChanges();
            }
        }
    }
}

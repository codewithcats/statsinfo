using StatsInfoSystem;
using System.Data.Entity;

namespace StsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<StsContext>());
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

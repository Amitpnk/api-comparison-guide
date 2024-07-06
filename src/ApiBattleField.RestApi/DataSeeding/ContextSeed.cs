using ApiBattleField.RestApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiBattleField.RestApi.DataSeeding
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            CreateCustomer(modelBuilder);
        }

        private static void CreateCustomer(ModelBuilder modelBuilder)
        {
            List<Customer> customers = DefaultCustomer.CustomerList();
            modelBuilder.Entity<Customer>().HasData(customers);
        }

    }
}

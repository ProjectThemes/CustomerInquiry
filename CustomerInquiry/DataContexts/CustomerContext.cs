using CustomerInquiry.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CustomerInquiry.DataContexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("CustomerConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(12, 2);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
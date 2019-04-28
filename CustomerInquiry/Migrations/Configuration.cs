namespace CustomerInquiry.Migrations
{
    using CustomerInquiry.Entities;
    using CustomerInquiry.Enumeration;
    using CustomerInquiry.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerInquiry.DataContexts.CustomerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomerInquiry.DataContexts.CustomerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var customers = new List<Customer>
            {
                new Customer { CustomerName = "Thanapon Phada-Anant", ContactEmail = "thanapon_p@live.com", MobileNo = "0988798464"},
                new Customer { CustomerName = "Anandh Gurpreet", ContactEmail = "anandf.g@gmail.com", MobileNo = "0988791242"},
                new Customer { CustomerName = "Hello CSharp", ContactEmail = "csharp.hello@outlook.com", MobileNo = "0981234464"},
                new Customer { CustomerName = "Entity Framework", ContactEmail = "ef@gmail.com", MobileNo = "0994445555"}
            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
                new Transaction { CustomerID = 1, TrasactionDate = DateTime.Now, Amount = 10000, CurrencyCode = CurrencyCode.THB.ToString(), Status = TransactionStatus.Success.ToString()},
                new Transaction { CustomerID = 1, TrasactionDate = DateTime.Now, Amount = 20000, CurrencyCode = CurrencyCode.SGD.ToString(), Status = TransactionStatus.Success.ToString()},
                new Transaction { CustomerID = 1, TrasactionDate = DateTime.Now, Amount = 30000, CurrencyCode = CurrencyCode.THB.ToString(), Status = TransactionStatus.Failed.ToString()},
                new Transaction { CustomerID = 2, TrasactionDate = DateTime.Now, Amount = 50.99M, CurrencyCode = CurrencyCode.USD.ToString(), Status = TransactionStatus.Success.ToString()},
            };

            transactions.ForEach(t => context.Transactions.Add(t));
            context.SaveChanges();
        }
    }
}

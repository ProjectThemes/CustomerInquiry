using CustomerInquiry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.DataContexts
{
    public class CustomerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CustomerContext>
    {
        protected override void Seed(CustomerContext context)
        {
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
                new Transaction { CustomerID = 1, TrasactionDate = DateTime.Now, Amount = 10000, CurrencyCode = Enumeration.CurrencyCode.THB, Status = Enumeration.TransactionStatus.Success},
                new Transaction { CustomerID = 1, TrasactionDate = DateTime.Now, Amount = 20000, CurrencyCode = Enumeration.CurrencyCode.SGD, Status = Enumeration.TransactionStatus.Success},
                new Transaction { CustomerID = 1, TrasactionDate = DateTime.Now, Amount = 30000, CurrencyCode = Enumeration.CurrencyCode.THB, Status = Enumeration.TransactionStatus.Failed},
                new Transaction { CustomerID = 2, TrasactionDate = DateTime.Now, Amount = 50.99M, CurrencyCode = Enumeration.CurrencyCode.USD, Status = Enumeration.TransactionStatus.Success},
            };

            transactions.ForEach(t => context.Transactions.Add(t));
            context.SaveChanges();
        }
    }
}
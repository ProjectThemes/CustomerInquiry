using System.Linq;
using CustomerInquiry.Entities;

namespace CustomerInquiry.Models
{
    public class CustomerFactory
    {
        public CustomerModel Create(Customer customer)
        {
            return new CustomerModel
            {
                CustomerID = customer.CustomerID,
                Name = customer.CustomerName,
                Email = customer.ContactEmail,
                Mobile = customer.MobileNo,
                Transactions = customer.Transactions.Take(5).OrderByDescending(t => t.TrasactionDate).Select(t => Create(t))
            };
        }

        public TransactionModel Create(Transaction transaction)
        {
            return new TransactionModel
            {
                Id = transaction.TransactionID,
                Date = transaction.TrasactionDate.ToString("dd/MM/yy HH:mm"),
                Amount = transaction.Amount, // No formatting because its a number with fixed precision
                Currency = transaction.CurrencyCode,
                Status = transaction.Status
            };
        }
    }
}
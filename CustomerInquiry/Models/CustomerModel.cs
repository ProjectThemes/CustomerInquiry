using CustomerInquiry.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public IEnumerable<TransactionModel> Transactions { get; set; }
    }

    public class CustomerPostModel
    {
        public string CustomerID { get; set; }
        public string Email { get; set; }
    }

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
                Date = transaction.TrasactionDate.ToString(), //TODO Date format
                Amount = transaction.Amount, //TODO 2 decimal place format
                Currency = transaction.CurrencyCode,
                Status = transaction.Status
            };
        }
    }
}
using CustomerInquiry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomer(int customerId);
        IEnumerable<Customer> GetCustomer(string customerEmail);
        IEnumerable<Customer> GetCustomer(int customerId, string customerEmail);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerInquiry.DataContexts;
using CustomerInquiry.Entities;

namespace CustomerInquiry.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> GetCustomer(int customerId)
        {
            return context.Customers.Where(c => c.CustomerID == customerId);
        }

        public IEnumerable<Customer> GetCustomer(string customerEmail)
        {
            return context.Customers.Where(c => c.ContactEmail == customerEmail);
        }

        public IEnumerable<Customer> GetCustomer(int customerId, string customerEmail)
        {
            return context.Customers
                            .Where(c => c.CustomerID == customerId)
                            .Where(c => c.ContactEmail == customerEmail);
        }
    }
}
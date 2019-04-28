using CustomerInquiry.DataContexts;
using CustomerInquiry.Enumeration;
using CustomerInquiry.Helpers;
using CustomerInquiry.Models;
using CustomerInquiry.Repositories;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace CustomerInquiry.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerRepository _repos;
        private CustomerFactory _factory;

        public CustomerController()
        {
            _repos = new CustomerRepository(new CustomerContext());
            _factory = new CustomerFactory();
        }
        public IHttpActionResult Post([FromBody]CustomerPostModel customerPost)
        {
            try
            {
                int customerId = 0;
                if (customerPost == null || (customerPost.CustomerID == null && customerPost.Email == null))
                {
                    return BadRequest("No inquiry criteria");
                }

                if (customerPost.Email != null)
                {
                    if (!Regex.IsMatch(customerPost.Email, @"^[a-zA-Z0-9_.+-]+@[email]+\.[a-zA-Z0-9-.]+$"))
                    {
                        return BadRequest("Invalid Email");
                    }
                }

                if (customerPost.CustomerID != null)
                {
                    if (!int.TryParse(customerPost.CustomerID, out customerId))
                    {
                        return BadRequest("Invalid CustomerID");
                    }

                    if (customerId == 0)
                    {
                        return BadRequest("Invalid CustomerID");
                    }
                }

                CustomerModel returnResult;
                if (customerPost.Email != null && customerId != 0)
                {
                    returnResult = _repos.GetCustomer(customerId, customerPost.Email)
                        .ToList()
                        .Select(c => _factory.Create(c))
                        .FirstOrDefault();
                }
                else if (customerPost.Email != null)
                {
                    returnResult = _repos.GetCustomer(customerPost.Email)
                        .ToList()
                        .Select(c => _factory.Create(c))
                        .FirstOrDefault();
                }
                else
                {
                    returnResult = _repos.GetCustomer(customerId)
                        .ToList()
                        .Select(c => _factory.Create(c))
                        .FirstOrDefault();
                }
                
                return Ok<CustomerModel>(returnResult);
            }
            catch (Exception ex)
            {
                return BadRequest("");
            }
        }
    }
}

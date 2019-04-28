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
        private const string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public CustomerController(ICustomerRepository repos)
        {
            _repos = repos;
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
                    if (!Regex.IsMatch(customerPost.Email, emailRegex))
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
                
                if(returnResult == null)
                {
                    return Ok(new { Message = "Not found" });
                }

                return Ok<CustomerModel>(returnResult);
            }
            catch
            {
                return BadRequest("");
            }
        }
    }
}

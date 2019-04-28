using CustomerInquiry.DataContexts;
using CustomerInquiry.Models;
using System;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace CustomerInquiry.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerContext _db;
        public CustomerController()
        {
            _db = new CustomerContext();
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

                }
                else if (customerPost.Email != null)
                {
                    
                }
                else
                {
                    
                }
                returnResult = new CustomerModel();
                return Ok<CustomerModel>(returnResult);
            }
            catch
            {
                return BadRequest("");
            }
        }
    }
}

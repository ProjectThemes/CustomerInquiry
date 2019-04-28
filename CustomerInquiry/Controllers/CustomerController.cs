using CustomerInquiry.DataContexts;
using CustomerInquiry.Enumeration;
using CustomerInquiry.Helpers;
using CustomerInquiry.Models;
using System;
using System.Linq;
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
                    returnResult = new CustomerModel();
                }
                else if (customerPost.Email != null)
                {
                    returnResult = new CustomerModel();
                }
                else
                {
                    returnResult = _db.Customers.Where(c => c.CustomerID == customerId).Select(c => new CustomerModel {
                        CustomerID = c.CustomerID,
                        Name = c.CustomerName,
                        Email = c.ContactEmail,
                        Mobile = c.MobileNo,
                        Transactions = c.Transactions.Take(5).OrderByDescending(t => t.TrasactionDate).Select(t => new TransactionModel {
                            Id = t.TransactionID,
                            Date = t.TrasactionDate.ToString(), //TODO Date format
                            Amount = t.Amount, //TODO 2 decimal place format
                            Currency =t.CurrencyCode,
                            Status = t.Status
                        })
                    }).FirstOrDefault();
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

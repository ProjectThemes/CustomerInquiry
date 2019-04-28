using CustomerInquiry.Models;
using System.Web.Http;

namespace CustomerInquiry.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult Post([FromBody]CustomerPostModel customerPost)
        {
            if (customerPost == null)
            {
                return BadRequest("No inquiry criteria");
            }


            return Ok<CustomerModel>(new CustomerModel());
        }
    }
}

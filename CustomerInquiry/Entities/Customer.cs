using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
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
        public int CustomerID { get; set; }
        public string Email { get; set; }
    }
}
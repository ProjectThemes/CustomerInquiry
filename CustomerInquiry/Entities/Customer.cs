using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [MaxLength(30)]
        public string CustomerName { get; set; }

        [MaxLength(25)]
        public string ContactEmail { get; set; }

        [MaxLength(10)]
        // Better be string instead of int cause of starting 0
        public string MobileNo { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
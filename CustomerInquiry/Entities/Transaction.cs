using CustomerInquiry.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public DateTime TrasactionDate { get; set; }
        public decimal Amount { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
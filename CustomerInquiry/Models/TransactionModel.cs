using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
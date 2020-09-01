using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Customertransaction
    {
        public decimal? Customerid { get; set; }
        public DateTime? Transactiondate { get; set; }
        public decimal? Employeeid { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public decimal? Reference { get; set; }
    }
}

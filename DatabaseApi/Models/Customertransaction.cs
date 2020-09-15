using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Customertransaction
    {
        public int Customerid { get; set; }
        public DateTime Transactiondate { get; set; }
        public int? Employeeid { get; set; }
        public int? Amount { get; set; }
        public string Description { get; set; }
        public int? Reference { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

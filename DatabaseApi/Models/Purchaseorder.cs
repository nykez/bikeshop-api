using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Purchaseorder
    {
        public decimal? Purchaseid { get; set; }
        public decimal? Employeeid { get; set; }
        public decimal? Manufacturerid { get; set; }
        public decimal? Totallist { get; set; }
        public decimal? Shippingcost { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Receivedate { get; set; }
        public decimal? Amountdue { get; set; }
    }
}

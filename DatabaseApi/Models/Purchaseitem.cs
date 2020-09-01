using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Purchaseitem
    {
        public decimal? Purchaseid { get; set; }
        public decimal? Componentid { get; set; }
        public decimal? Pricepaid { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Quantityreceived { get; set; }
    }
}

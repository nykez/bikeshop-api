using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Purchaseitem
    {
        public int Purchaseid { get; set; }
        public int Componentid { get; set; }
        public int? Pricepaid { get; set; }
        public int? Quantity { get; set; }
        public int? Quantityreceived { get; set; }

        public virtual Component Component { get; set; }
        public virtual Purchaseorder Purchase { get; set; }
    }
}

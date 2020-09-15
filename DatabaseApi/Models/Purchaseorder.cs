using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Purchaseorder
    {
        public Purchaseorder()
        {
            Purchaseitem = new HashSet<Purchaseitem>();
        }

        public int Purchaseid { get; set; }
        public int? Employeeid { get; set; }
        public int? Manufacturerid { get; set; }
        public int? Totallist { get; set; }
        public int? Shippingcost { get; set; }
        public int? Discount { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Receivedate { get; set; }
        public int? Amountdue { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Purchaseitem> Purchaseitem { get; set; }
    }
}

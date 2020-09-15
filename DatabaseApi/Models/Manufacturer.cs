using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Component = new HashSet<Component>();
            Manufacturertransaction = new HashSet<Manufacturertransaction>();
            Purchaseorder = new HashSet<Purchaseorder>();
        }

        public int Manufacturerid { get; set; }
        public string Manufacturername { get; set; }
        public string Contactname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int? Cityid { get; set; }
        public int? Balancedue { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Component> Component { get; set; }
        public virtual ICollection<Manufacturertransaction> Manufacturertransaction { get; set; }
        public virtual ICollection<Purchaseorder> Purchaseorder { get; set; }
    }
}

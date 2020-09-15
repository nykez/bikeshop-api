using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Customer
    {
        public Customer()
        {
            Bicycle = new HashSet<Bicycle>();
            Customertransaction = new HashSet<Customertransaction>();
        }

        public int Customerid { get; set; }
        public string Phone { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int? Cityid { get; set; }
        public int? Balancedue { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Bicycle> Bicycle { get; set; }
        public virtual ICollection<Customertransaction> Customertransaction { get; set; }
    }
}

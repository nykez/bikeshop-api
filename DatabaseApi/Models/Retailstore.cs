using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Retailstore
    {
        public Retailstore()
        {
            Bicycle = new HashSet<Bicycle>();
        }

        public int Storeid { get; set; }
        public string Storename { get; set; }
        public string Phone { get; set; }
        public string Contactfirstname { get; set; }
        public string Contactlastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int? Cityid { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Bicycle> Bicycle { get; set; }
    }
}

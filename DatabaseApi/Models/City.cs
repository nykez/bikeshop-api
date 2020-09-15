using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class City
    {
        public City()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
            Manufacturer = new HashSet<Manufacturer>();
            Retailstore = new HashSet<Retailstore>();
        }

        public int Cityid { get; set; }
        public string Zipcode { get; set; }
        public string City1 { get; set; }
        public string State { get; set; }
        public string Areacode { get; set; }
        public int? Population1990 { get; set; }
        public int? Population1980 { get; set; }
        public string Country { get; set; }
        public int? Latitude { get; set; }
        public int? Longitude { get; set; }
        public int? Populationcdf { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Manufacturer> Manufacturer { get; set; }
        public virtual ICollection<Retailstore> Retailstore { get; set; }
    }
}

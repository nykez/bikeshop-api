using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Employee
    {
        public Employee()
        {
            Bicycle = new HashSet<Bicycle>();
            Bikeparts = new HashSet<Bikeparts>();
            Purchaseorder = new HashSet<Purchaseorder>();
        }

        public int Employeeid { get; set; }
        public string Taxpayerid { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Homephone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int? Cityid { get; set; }
        public DateTime? Datehired { get; set; }
        public DateTime? Datereleased { get; set; }
        public int? Currentmanager { get; set; }
        public int? Salarygrade { get; set; }
        public int? Salary { get; set; }
        public string Title { get; set; }
        public string Workarea { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Bicycle> Bicycle { get; set; }
        public virtual ICollection<Bikeparts> Bikeparts { get; set; }
        public virtual ICollection<Purchaseorder> Purchaseorder { get; set; }
    }
}

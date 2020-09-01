using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Customer
    {
        public decimal? Customerid { get; set; }
        public string Phone { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public decimal? Cityid { get; set; }
        public decimal? Balancedue { get; set; }
    }
}

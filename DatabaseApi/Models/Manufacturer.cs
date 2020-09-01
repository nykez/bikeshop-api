using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Manufacturer
    {
        public decimal? Manufacturerid { get; set; }
        public string Manufacturername { get; set; }
        public string Contactname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public decimal? Cityid { get; set; }
        public decimal? Balancedue { get; set; }
    }
}

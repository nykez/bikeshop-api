using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Retailstore
    {
        public decimal? Storeid { get; set; }
        public string Storename { get; set; }
        public string Phone { get; set; }
        public string Contactfirstname { get; set; }
        public string Contactlastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public decimal? Cityid { get; set; }
    }
}

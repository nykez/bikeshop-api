using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Bikeparts
    {
        public decimal? Serialnumber { get; set; }
        public decimal? Componentid { get; set; }
        public decimal? Substituteid { get; set; }
        public string Location { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Dateinstalled { get; set; }
        public decimal? Employeeid { get; set; }
    }
}

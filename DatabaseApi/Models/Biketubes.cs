using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Biketubes
    {
        public decimal? Serialnumber { get; set; }
        public string Tubename { get; set; }
        public decimal? Tubeid { get; set; }
        public decimal? Length { get; set; }
    }
}

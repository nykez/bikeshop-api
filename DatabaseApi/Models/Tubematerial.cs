using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Tubematerial
    {
        public decimal? Tubeid { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public decimal? Diameter { get; set; }
        public decimal? Thickness { get; set; }
        public string Roundness { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Stiffness { get; set; }
        public decimal? Listprice { get; set; }
        public string Construction { get; set; }
    }
}

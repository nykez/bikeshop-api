using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Component
    {
        public decimal? Componentid { get; set; }
        public decimal? Manufacturerid { get; set; }
        public string Productnumber { get; set; }
        public string Road { get; set; }
        public string Category { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Year { get; set; }
        public decimal? Endyear { get; set; }
        public string Description { get; set; }
        public decimal? Listprice { get; set; }
        public decimal? Estimatedcost { get; set; }
        public decimal? Quantityonhand { get; set; }
    }
}

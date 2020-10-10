using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Dtos
{
    public class ComponetToUpdate
    {
        public int? Manufacturerid { get; set; }
        public string Productint { get; set; }
        public string Road { get; set; }
        public string Category { get; set; }
        public int? Length { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? Weight { get; set; }
        public int? Year { get; set; }
        public int? Endyear { get; set; }
        public string Description { get; set; }
        public int? Listprice { get; set; }
        public int? Estimatedcost { get; set; }
        public int? Quantityonhand { get; set; }
    }
}

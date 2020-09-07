using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Tubematerial
    {
        public Tubematerial()
        {
            Bicycletubeusage = new HashSet<Bicycletubeusage>();
            Biketubes = new HashSet<Biketubes>();
        }

        public int Tubeid { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public int? Diameter { get; set; }
        public int? Thickness { get; set; }
        public string Roundness { get; set; }
        public int? Weight { get; set; }
        public int? Stiffness { get; set; }
        public int? Listprice { get; set; }
        public string Construction { get; set; }

        public virtual ICollection<Bicycletubeusage> Bicycletubeusage { get; set; }
        public virtual ICollection<Biketubes> Biketubes { get; set; }
    }
}

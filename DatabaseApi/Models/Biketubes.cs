using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Biketubes
    {
        public int Serialnumber { get; set; }
        public string Tubename { get; set; }
        public int? Tubeid { get; set; }
        public int? Length { get; set; }

        public virtual Bicycle SerialnumberNavigation { get; set; }
        public virtual Tubematerial Tube { get; set; }
    }
}

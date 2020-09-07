using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Bicycletubeusage
    {
        public int Serialnumber { get; set; }
        public int Tubeid { get; set; }
        public int? Quantity { get; set; }

        public virtual Bicycle SerialnumberNavigation { get; set; }
        public virtual Tubematerial Tube { get; set; }
    }
}

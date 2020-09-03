using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Bikeparts
    {
        public int Serialnumber { get; set; }
        public int Componentid { get; set; }
        public int? Substituteid { get; set; }
        public string Location { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Dateinstalled { get; set; }
        public int? Employeeid { get; set; }

        public virtual Component Component { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Bicycle SerialnumberNavigation { get; set; }
    }
}

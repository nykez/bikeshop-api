using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Modeltype
    {
        public Modeltype()
        {
            Bicycle = new HashSet<Bicycle>();
            Modelsize = new HashSet<Modelsize>();
        }

        public string Modeltype1 { get; set; }
        public string Description { get; set; }
        public int? Componentid { get; set; }

        public virtual ICollection<Bicycle> Bicycle { get; set; }
        public virtual ICollection<Modelsize> Modelsize { get; set; }
    }
}

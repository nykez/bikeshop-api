using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Groupo
    {
        public Groupo()
        {
            Groupcomponents = new HashSet<Groupcomponents>();
        }

        public int Componentgroupid { get; set; }
        public string Groupname { get; set; }
        public string Biketype { get; set; }
        public int? Year { get; set; }
        public int? Endyear { get; set; }
        public int? Weight { get; set; }

        public virtual ICollection<Groupcomponents> Groupcomponents { get; set; }
    }
}

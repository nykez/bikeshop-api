using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Componentname
    {
        public Componentname()
        {
            Component = new HashSet<Component>();
        }

        public string Componentname1 { get; set; }
        public int? Assemblyorder { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Component> Component { get; set; }
    }
}

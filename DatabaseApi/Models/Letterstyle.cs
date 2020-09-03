using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Letterstyle
    {
        public Letterstyle()
        {
            Bicycle = new HashSet<Bicycle>();
        }

        public string Letterstyle1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Bicycle> Bicycle { get; set; }
    }
}

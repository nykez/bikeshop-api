using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Groupcomponents
    {
        public int Groupid { get; set; }
        public int Componentid { get; set; }

        public virtual Component Component { get; set; }
        public virtual Groupo Group { get; set; }
    }
}

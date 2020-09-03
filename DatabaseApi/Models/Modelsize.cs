using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Modelsize
    {
        public string Modeltype { get; set; }
        public int Msize { get; set; }
        public int? Toptube { get; set; }
        public int? Chainstay { get; set; }
        public int? Totallength { get; set; }
        public int? Groundclearance { get; set; }
        public int? Headtubeangle { get; set; }
        public int? Seattubeangle { get; set; }

        public virtual Modeltype ModeltypeNavigation { get; set; }
    }
}

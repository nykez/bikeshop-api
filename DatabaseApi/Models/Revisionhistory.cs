using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Revisionhistory
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public DateTime? Changedate { get; set; }
        public string Name { get; set; }
        public string Revisioncomments { get; set; }
    }
}

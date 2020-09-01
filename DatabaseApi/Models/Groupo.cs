using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Groupo
    {
        public decimal? Componentgroupid { get; set; }
        public string Groupname { get; set; }
        public string Biketype { get; set; }
        public decimal? Year { get; set; }
        public decimal? Endyear { get; set; }
        public decimal? Weight { get; set; }
    }
}

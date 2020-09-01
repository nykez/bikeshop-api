using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Modelsize
    {
        public string Modeltype { get; set; }
        public decimal? Msize { get; set; }
        public decimal? Toptube { get; set; }
        public decimal? Chainstay { get; set; }
        public decimal? Totallength { get; set; }
        public decimal? Groundclearance { get; set; }
        public decimal? Headtubeangle { get; set; }
        public decimal? Seattubeangle { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Statetaxrate
    {
        public string State { get; set; }
        public decimal? Taxrate { get; set; }
    }
}

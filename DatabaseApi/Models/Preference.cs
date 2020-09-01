using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Preference
    {
        public string Itemname { get; set; }
        public decimal? Value { get; set; }
        public string Description { get; set; }
        public DateTime? Datechanged { get; set; }
    }
}

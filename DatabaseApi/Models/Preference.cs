using System;
using System.Collections.Generic;

namespace DatabaseApi
{
    public partial class Preference
    {
        public string Itemname { get; set; }
        public int? Value { get; set; }
        public string Description { get; set; }
        public DateTime? Datechanged { get; set; }
    }
}

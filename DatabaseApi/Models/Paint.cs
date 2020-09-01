using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class Paint
    {
        public decimal? Paintid { get; set; }
        public string Colorname { get; set; }
        public string Colorstyle { get; set; }
        public string Colorlist { get; set; }
        public DateTime? Dateintroduced { get; set; }
        public DateTime? Datediscontinued { get; set; }
    }
}

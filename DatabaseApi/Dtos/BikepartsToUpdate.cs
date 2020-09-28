using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Dtos {
	public class BikepartsToUpdate {
        public int? Substituteid { get; set; }
        public string Location { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Dateinstalled { get; set; }
        public int? Employeeid { get; set; }
    }
}

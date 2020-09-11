using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Dtos
{
    public class BikepartsToCreate
    {
        [Required]
        public int Serialnumber { get; set; }
        [Required]
        public int Componentid { get; set; }
        public int? Substituteid { get; set; }
        [Required]
        public string Location { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Dateinstalled { get; set; }
        public int? Employeeid { get; set; }
    }
}

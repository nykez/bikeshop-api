


using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApi.Dtos {
    /// <summary>
    /// DTO object for creating new entries of <see cref="Paint"/> in the database.
    /// </summary>
    public class PaintToCreate {
        [Required]
        public string Colorname { get; set; }
        [Required]
        public string Colorstyle { get; set; }
        [Required]
        public string Colorlist { get; set; }
        
        
        public DateTime? Dateintroduced { get; set; }
        public DateTime? Datediscontinued { get; set; }
    }
}
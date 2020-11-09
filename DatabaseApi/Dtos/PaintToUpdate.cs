using System;

namespace DatabaseApi.Dtos {
    /// <summary>
    /// DTO object for updating existing entries of <see cref="Paint"/> in the database.
    /// </summary>
    public class PaintToUpdate {
        public string Colorname { get; set; }
        public string Colorstyle { get; set; }
        public string Colorlist { get; set; }


        public DateTime? Dateintroduced { get; set; }
        public DateTime? Datediscontinued { get; set; }
    }
}
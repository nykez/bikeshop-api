
using System.ComponentModel.DataAnnotations;

namespace DatabaseApi.Dtos
{
    /// <summary>
    /// Retailstore DTO (Data transfer object)
    /// </summary>
    public class RetailstoreToCreate
    {
        [Required]
        public int Storeid { get; set; }
        public string Storename { get; set; }
        public string Phone { get; set; }
        public string Contactfirstname { get; set; }
        public string Contactlastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        
        public int? Cityid { get; set; }

    }
}

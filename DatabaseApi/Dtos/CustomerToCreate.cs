using System.ComponentModel.DataAnnotations;

namespace DatabaseApi.Dtos
{
    /// <summary>
    /// Customer DTO (Data transfer object)
    /// </summary>
    public class CustomerToCreate
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Zipcode { get; set; }

        public int? Cityid { get; set; }
        public int? Balancedue { get; set; }
    }
}
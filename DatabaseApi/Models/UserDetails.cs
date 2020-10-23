using System.ComponentModel.DataAnnotations;

namespace DatabaseApi.Models
{
    public class UserDetails
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
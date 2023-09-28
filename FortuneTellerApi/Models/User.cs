using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }      
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}

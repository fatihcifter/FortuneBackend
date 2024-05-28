using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string GsmNumber { get; set; }
        [Required]
        public string RegistrationDate { get; set; }
        [Required]
        public string LastLoginDate { get; set; }
        [Required]
        public int RegistrationAddressId { get; set; }
    }
}

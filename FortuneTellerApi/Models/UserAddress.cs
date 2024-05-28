using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}

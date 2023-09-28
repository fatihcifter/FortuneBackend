using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class FortuneTeller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Base64Image { get; set; }
        [Required]
        public double Rate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class FortuneInfo
    {
        [Key]
        public int FortuneId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FortuneTellerId { get; set; }     
        [Required]
        public bool IsPayed { get; set; }
        
    }
}

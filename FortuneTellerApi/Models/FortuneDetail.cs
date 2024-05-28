using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class FortuneDetail
    {
        [Key]
        public int FortuneId { get; set; }
        [Required]
        public string FortuneInformation { get; set; }
        
    }
}

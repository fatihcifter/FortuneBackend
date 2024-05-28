using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class FortuneImageInfo
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public int FortuneId { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
    }
}

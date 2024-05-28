using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class FortunePrice
    {
        [Key]
        public int PriceId { get; set; }
        [Required]
        public double TurkishPrice { get; set; }
        [Required]
        public FortuneType FortuneType { get; set; }
    }
}

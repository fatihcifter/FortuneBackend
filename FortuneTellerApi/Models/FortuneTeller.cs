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
        [Required]
        public bool Coffee { get; set; }
        [Required]
        public double CoffeePrice { get; set; }
        [Required]
        public bool Tarot { get; set; }
        [Required]
        public double TarotPrice { get; set; }
        [Required]
        public bool Water { get; set; }
        [Required]
        public double WaterPrice { get; set; }
        [Required]
        public bool Birthmap { get; set; }
        [Required]
        public double BirthmapPrice { get; set; }
        [Required]
        public bool PlayingCard { get; set; }
        [Required]
        public double PlayingCardPrice { get; set; }
    }
}

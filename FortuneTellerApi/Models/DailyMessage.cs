﻿using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public class DailyMessage
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string MessageBody { get; set; }
        [Required]
        public string MessageHeader { get; set; }
        [Required]
        public DateTime EstimatedPublishTime { get; set; }
        public string Author { get; set; } = string.Empty;
    }
}

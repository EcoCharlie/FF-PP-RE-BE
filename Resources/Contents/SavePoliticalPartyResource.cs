using System;
using System.ComponentModel.DataAnnotations;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class SavePoliticalPartyResource
    {
        [Required]
        [MaxLength(50)]
        public string PoliticalPartyName { get; set; }
        [Required]
        [MaxLength(50)]
        public string PresidentName { get; set; }
        [Required]
        public DateTime FoundationDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ideology { get; set; }
        [Required]
        [MaxLength(50)]
        public string Position { get; set; }
        [Required]
        [MaxLength(300)]
        public string PictureLink { get; set; }
    }
}
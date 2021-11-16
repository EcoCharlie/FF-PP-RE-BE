using System;
using System.ComponentModel.DataAnnotations;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class SaveMilitantResource
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(30)]
        public string BirthPlace { get; set; }
        [Required]
        [MaxLength(50)]
        public string Profession { get; set; }
        [Required]
        [MaxLength(300)]
        public string PictureLink { get; set; }
        [Required]
        public bool IsPresident { get; set; }
    }
}
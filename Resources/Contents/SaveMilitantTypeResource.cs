using System.ComponentModel.DataAnnotations;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class SaveMilitantTypeResource
    {
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
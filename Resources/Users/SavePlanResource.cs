using System.ComponentModel.DataAnnotations;

namespace PiensaPeruAPIWeb.Resources.Users
{
    public class SavePlanResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
    }
}

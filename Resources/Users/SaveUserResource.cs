using System.ComponentModel.DataAnnotations;

namespace PiensaPeruAPIWeb.Resources.Users
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}

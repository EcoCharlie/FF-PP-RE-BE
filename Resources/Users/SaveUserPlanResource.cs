using System;
using System.ComponentModel.DataAnnotations;

namespace PiensaPeruAPIWeb.Resources.Users
{
    public class SaveUserPlanResource
    {
        [Required]
        public DateTime ActivatedDate { get; set; }
    }
}

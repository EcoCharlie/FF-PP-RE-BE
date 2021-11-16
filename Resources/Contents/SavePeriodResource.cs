using System;
using System.ComponentModel.DataAnnotations;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class SavePeriodResource
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string OriginOfChange { get; set; }
    }
}
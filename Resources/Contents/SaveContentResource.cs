using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class SaveContentResource
    {
        [Required]
        public bool Active { get; set; }
    }
}
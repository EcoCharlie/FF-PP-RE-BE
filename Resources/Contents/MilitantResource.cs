using System;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class MilitantResource
    {
        public int MilitantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Profession { get; set; }
        public string PictureLink { get; set; }
        public bool IsPresident { get; set; }
    }
}
using System;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class PoliticalPartyResource
    {
        public int PoliticalPartyId { get; set; }
        public string PoliticalPartyName { get; set; }
        public string PresidentName { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Ideology { get; set; }
        public string Position { get; set; }
        public string PictureLink { get; set; }
    }
}
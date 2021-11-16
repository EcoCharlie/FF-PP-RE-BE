using System;
using System.Collections;
using System.Collections.Generic;

namespace PiensaPeruAPIWeb.Domain.Models.Contents
{
    public class PoliticalParty
    {
        public int PoliticalPartyId { get; set; }
        public string PoliticalPartyName { get; set; }
        public string PresidentName { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Ideology { get; set; }
        public string Position { get; set; }
        public string PictureLink { get; set; }
        
        //RelationShip-Militant
        public IList<Militant> Militants { get; set; } = new List<Militant>();
    }
}
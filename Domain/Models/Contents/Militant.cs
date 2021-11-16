using System;
using System.Collections.Generic;
using PiensaPeruAPIWeb.Controllers.Contents;

namespace PiensaPeruAPIWeb.Domain.Models.Contents
{
    public class Militant : Person
    {
        public int MilitantId { get; set; } = new Person().Id;
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Profession { get; set; }
        public string PictureLink { get; set; }
        public bool IsPresident { get; set; }
        
        //RelationShip-PoliticalParty
        public int PoliticalPartyId { get; set; }
        public PoliticalParty PoliticalParty { get; set; }
        
        //RelationShip-MilitantType
        public int MilitantTypeId { get; set; }
        public MilitantType MilitantType { get; set; }
        
        //RelationShip-MilitantContent
        public IList<MilitantContent> MilitantContents { get; set; } = new List<MilitantContent>();
    }
}
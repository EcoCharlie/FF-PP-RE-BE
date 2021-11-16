using System;
using System.Collections.Generic;

namespace PiensaPeruAPIWeb.Domain.Models.Contents
{
    public class Period
    {
        public int PeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OriginOfChange { get; set; }
        
        //RelationShip-
        public IList<MilitantContent> MilitantContents { get; set; } = new List<MilitantContent>();
    }
}
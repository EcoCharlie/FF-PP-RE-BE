using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing.Matching;

namespace PiensaPeruAPIWeb.Domain.Models.Contents
{
    public class MilitantType
    {
        public int MilitantTypeId { get; set; }
        public string Type { get; set; }
        
        //RelationShip-Militant
        public IList<Militant> Militants { get; set; } = new List<Militant>();
    }
}
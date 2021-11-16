using System.Collections;
using System.Collections.Generic;
namespace PiensaPeruAPIWeb.Domain.Models.Contents
{
    public class Content
    {
        public int ContentId { get; set; }
        public bool Active { get; set; }
        
        //RelationShip - MilitantContent
        public IList<MilitantContent> MilitantContents { get; set; } = new List<MilitantContent>();
    }
}
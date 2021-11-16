namespace PiensaPeruAPIWeb.Domain.Models.Contents
{
    public class MilitantContent
    {
        //RelationShips-Militant
        public int MilitantId { get; set; }
        public Militant Militant { get; set; }
        
        //RelationShips-Content
        public int ContentId { get; set; }
        public Content Content { get; set; }
        
        //RelationShip-Period
        public int PeriodId { get; set; }
        public Period Period { get; set; }
    }
}
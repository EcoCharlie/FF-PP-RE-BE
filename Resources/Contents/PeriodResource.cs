using System;

namespace PiensaPeruAPIWeb.Resources.Contents
{
    public class PeriodResource
    {
        public int PeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OriginOfChange { get; set; }
    }
}
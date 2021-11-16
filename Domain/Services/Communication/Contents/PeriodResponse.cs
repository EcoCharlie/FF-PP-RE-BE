using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class PeriodResponse : BaseResponse
    {
        public Period Period { get; set; }
        public PeriodResponse(bool success, string message, Period period) : base(success, message)
        {
            Period = period;
        }
        
        public PeriodResponse(Period period) : this(true, string.Empty, period) { }

        public PeriodResponse(string message) : this(false, message, null) { }
    }
}
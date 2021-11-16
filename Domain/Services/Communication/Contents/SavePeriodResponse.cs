using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class SavePeriodResponse : BaseResponse
    {
        public Period Period { get; private set; }
        public SavePeriodResponse(bool success, string message, Period period) : base(success, message)
        {
            Period = period;
        }
        public SavePeriodResponse(Period period) : this(true, string.Empty, period) { }
        public SavePeriodResponse(string message) : this(false, string.Empty, null) { }

    }
}
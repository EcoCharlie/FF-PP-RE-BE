
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class MilitantTypeResponse : BaseResponse
    {
        public MilitantType MilitantType { get; set; }
        public MilitantTypeResponse(bool success, string message, MilitantType militantType) : base(success, message)
        {
            MilitantType = militantType;
        }
        
        public MilitantTypeResponse(MilitantType militantType) : this(true, string.Empty, militantType) { }

        public MilitantTypeResponse(string message) : this(false, message, null) { }
    }
}
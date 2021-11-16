using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class MilitantContentResponse : BaseResponse
    {
        public MilitantContent MilitantContent { get; set; }
        public MilitantContentResponse(bool success, string message, MilitantContent militantContent) : base(success, message)
        {
            MilitantContent = militantContent;
        }
        public MilitantContentResponse(MilitantContent militantContent) : this(true, string.Empty, militantContent) { }

        public MilitantContentResponse(string message) : this(false, message, null) { }
    }
}
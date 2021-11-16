using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class SaveMilitantContentResponse : BaseResponse
    {
        public MilitantContent MilitantContent { get; private set; }
        public SaveMilitantContentResponse(bool success, string message, MilitantContent militantContent) : base(success, message)
        {
            MilitantContent = militantContent;
        }
        public SaveMilitantContentResponse(MilitantContent militantContent) : this(true, string.Empty, militantContent) { }
        public SaveMilitantContentResponse(string message) : this(false, string.Empty, null) { }
    }
}
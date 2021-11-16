
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class SaveContentResponse : BaseResponse
    {
        public Content Content { get; private set; }
        public SaveContentResponse(bool success, string message, Content content) : base(success, message)
        {
            Content = content;
        }
        public SaveContentResponse(Content content) : this(true,string.Empty, content) { }
        public SaveContentResponse(string message) : this(false, string.Empty, null) { }
    }
}
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class ContentResponse : BaseResponse
    {
        public Content Content { get; set; }
        public ContentResponse(bool success, string message, Content content) : base(success, message)
        {
            Content = content;
        }
        public ContentResponse(Content content) : this(true, string.Empty, content) { }
        public ContentResponse(string message) : this(false, message, null) { }
    }
}
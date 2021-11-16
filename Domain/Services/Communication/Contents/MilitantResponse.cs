using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class MilitantResponse : BaseResponse
    {
        public Militant Militant { get; set; }
        public MilitantResponse(bool success, string message, Militant militant) : base(success, message)
        {
            Militant = militant;
        }
        
        public MilitantResponse(Militant militant) : this(true, string.Empty, militant) { }

        public MilitantResponse(string message) : this(false, message, null) { }
    }
}
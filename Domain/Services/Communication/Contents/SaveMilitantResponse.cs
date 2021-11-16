using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class SaveMilitantResponse : BaseResponse
    {
        public Militant Militant { get; private set; }
        public SaveMilitantResponse(bool success, string message, Militant militant) : base(success, message)
        {
            Militant = militant;
        }
        public SaveMilitantResponse(Militant militant) : this(true, string.Empty, militant) { }
        public SaveMilitantResponse(string message) : this(false, string.Empty, null) { }
    }
}
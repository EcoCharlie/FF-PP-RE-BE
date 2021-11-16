using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class SaveMilitantTypeResponse : BaseResponse
    {
        public MilitantType MilitantType { get; private set; }
        public SaveMilitantTypeResponse(bool success, string message, MilitantType militantType) : base(success, message)
        {
            MilitantType = militantType;
        }
        public SaveMilitantTypeResponse(MilitantType militantType) : this(true, string.Empty, militantType) { }
        public SaveMilitantTypeResponse(string message) : this(false, string.Empty, null) { }

    }
}
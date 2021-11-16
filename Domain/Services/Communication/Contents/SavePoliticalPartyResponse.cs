using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class SavePoliticalPartyResponse : BaseResponse
    {
        public PoliticalParty PoliticalParty { get; private set; }
        public SavePoliticalPartyResponse(bool success, string message, PoliticalParty politicalParty) : base(success, message)
        {
            PoliticalParty = politicalParty;
        }
        public SavePoliticalPartyResponse(PoliticalParty politicalParty) : this(true, string.Empty, politicalParty) { }
        public SavePoliticalPartyResponse(string message) : this(false, string.Empty, null) { }
    }
}
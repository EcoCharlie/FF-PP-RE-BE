using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Contents
{
    public class PoliticalPartyResponse : BaseResponse
    {
        public PoliticalParty PoliticalParty { get; set; }
        public PoliticalPartyResponse(bool success, string message, PoliticalParty politicalParty) : base(success, message)
        {
            PoliticalParty = politicalParty;
        }

        public PoliticalPartyResponse(PoliticalParty politicalParty) : this(true, string.Empty, politicalParty) { }

        public PoliticalPartyResponse(string message) : this(false, message, null) { }
    }
}
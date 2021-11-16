using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class PoliticalPartyReToPoliticalPartyProfile : Profile
    {
        public PoliticalPartyReToPoliticalPartyProfile()
        {
            CreateMap<SavePoliticalPartyResource, PoliticalParty>();
        }
    }
}
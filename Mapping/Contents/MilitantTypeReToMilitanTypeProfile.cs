using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Persistence.Repositories.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class MilitantTypeReToMilitantProfile : Profile
    {
        public MilitantTypeReToMilitantProfile()
        {
            CreateMap<SaveMilitantTypeResource, MilitantType>();
        }
    }
}
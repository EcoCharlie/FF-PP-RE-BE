using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class MilitantContentReToMilitantContentProfile : Profile
    {
        public MilitantContentReToMilitantContentProfile()
        {
            CreateMap<SaveMilitantContentResource, MilitantContent>();
        }
    }
}
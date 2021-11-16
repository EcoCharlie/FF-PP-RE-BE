using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class MilitantTypeToMilitantTypeReProfile : Profile
    {
        public MilitantTypeToMilitantTypeReProfile()
        {
            CreateMap<MilitantType, MilitantTypeResource>();
        }
    }
}
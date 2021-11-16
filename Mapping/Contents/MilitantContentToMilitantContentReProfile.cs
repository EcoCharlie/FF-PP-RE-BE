using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class MilitantContentToMilitantContentReProfile : Profile
    {
        public MilitantContentToMilitantContentReProfile()
        {
            CreateMap<MilitantContent, MilitantContentResource>();
        }
    }
}
using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class MilitantReToMilitantProfile : Profile
    {
        public MilitantReToMilitantProfile()
        {
            CreateMap<SaveMilitantResource, Militant>();
        }
    }
}
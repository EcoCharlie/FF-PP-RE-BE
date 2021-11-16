using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class ContentReToContentProfile : Profile
    {
        public ContentReToContentProfile()
        {
            CreateMap<SaveContentResource, Content>();
        }
    }
}
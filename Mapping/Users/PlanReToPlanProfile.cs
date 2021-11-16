using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Resources.Users;

namespace PiensaPeruAPIWeb.Mapping.Users
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlanResource, Plan>();
        }
    }
    
}

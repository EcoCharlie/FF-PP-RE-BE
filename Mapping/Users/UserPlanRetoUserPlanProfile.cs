using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Resources.Users;

namespace PiensaPeruAPIWeb.Mapping.Users
{
    public class UserPlanRetoUserPlanProfile : Profile
    {
        public UserPlanRetoUserPlanProfile()
        {
            CreateMap<SaveUserPlanResource, UserPlan>();
        }
    }
}
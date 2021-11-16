using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Resources.Users;

namespace PiensaPeruAPIWeb.Mapping.Users
{
    public class UserPlanToUserPlanReProfile : Profile
    {
        public UserPlanToUserPlanReProfile()
        {
            CreateMap<UserPlan, UserPlanResource>();
        }
    }
}
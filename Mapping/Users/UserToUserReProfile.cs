using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Resources.Users;

namespace PiensaPeruAPIWeb.Mapping.Users
{
    public class UserToUserReProfile : Profile
    {
        public UserToUserReProfile()
        {
            CreateMap<User, UserResource>();
        }
    }
}
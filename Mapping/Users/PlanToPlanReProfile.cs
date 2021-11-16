﻿using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Resources.Users;

namespace PiensaPeruAPIWeb.Mapping.Users
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Plan, PlanResource>();
        }
    }
}

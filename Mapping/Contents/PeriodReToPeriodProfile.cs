using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class PeriodReToPeriodProfile : Profile
    {
        public PeriodReToPeriodProfile()
        {
            CreateMap<SavePeriodResource, Period>();
        }
    }
}
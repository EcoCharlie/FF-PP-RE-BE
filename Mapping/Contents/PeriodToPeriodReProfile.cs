using AutoMapper;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Mapping.Contents
{
    public class PeriodToPeriodReProfile : Profile
    {
        public PeriodToPeriodReProfile()
        {
            CreateMap<Period, PeriodResource>();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Contents
{
    public interface IPeriodService
    {
        //get
        Task<IEnumerable<Period>> ListAsync();
        //post
        Task<SavePeriodResponse> SaveAsync(Period period);
        //update
        Task<SavePeriodResponse> UpdateAsync(int id, Period period);
        //delete
        Task<PeriodResponse> DeleteAsync(int id);
    }
}
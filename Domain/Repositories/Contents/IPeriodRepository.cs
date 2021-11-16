using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Repositories.Contents
{
    public interface IPeriodRepository
    {
        //get
        Task<IEnumerable<Period>> ListAsync();
        //post
        Task AddAsync(Period period);
        //update
        Task<Period> FindByIdAsync(int id);
        void Update(Period period);
        //delete
        void Remove(Period period);
    }
}
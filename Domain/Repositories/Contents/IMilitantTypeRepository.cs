using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Repositories.Contents
{
    public interface IMilitantTypeRepository
    {
        //get
        Task<IEnumerable<MilitantType>> ListAsync();
        //post
        Task AddAsync(MilitantType militantType);
        //update
        Task<MilitantType> FindByIdAsync(int id);
        void Update(MilitantType militantType);
        //delete
        void Remove(MilitantType militantType);
    }
}
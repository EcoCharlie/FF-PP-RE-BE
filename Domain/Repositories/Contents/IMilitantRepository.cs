using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Repositories.Contents
{
    public interface IMilitantRepository
    {
        //get
        Task<IEnumerable<Militant>> ListAsync();
        //post
        Task AddAsync(Militant militant);
        //update
        Task<Militant> FindByIdAsync(int id);
        void Update(Militant militant);
        //delete
        void Remove(Militant militant);
    }
}
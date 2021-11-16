using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Repositories.Contents
{
    public interface IMilitantContentRepository
    {
        //Get
        Task<IEnumerable<MilitantContent>> ListAsync();
        //Post
        Task AddAsync(MilitantContent militantContent);
        //Update
        Task<MilitantContent> FindByIdAsync(int id);
        void Update(MilitantContent militantContent);
        //delete
        void Remove(MilitantContent militantContent);
    }
}
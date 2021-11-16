using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Repositories.Contents
{
    public interface IContentRepository
    {
        //Get
        Task<IEnumerable<Content>> ListAsync();
        //Post
        Task AddAsync(Content content);
        //Update
        Task<Content> FindByIdAsync(int id);
        void Update(Content content);
        //delete
        void Remove(Content content);
    }
}
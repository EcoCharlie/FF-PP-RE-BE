using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Contents
{
    public interface IContentService
    {
        //get
        Task<IEnumerable<Content>> ListAsync();
        //post
        Task<SaveContentResponse> SaveAsync(Content content);
        //update
        Task<SaveContentResponse> UpdateAsync(int id, Content content);
        //delete
        Task<ContentResponse> DeleteAsync(int id);
    }
}
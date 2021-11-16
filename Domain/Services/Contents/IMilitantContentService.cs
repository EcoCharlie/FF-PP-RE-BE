using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Contents
{
    public interface IMilitantContentService
    {
        //get
        Task<IEnumerable<MilitantContent>> ListAsync();
        //post
        Task<SaveMilitantContentResponse> SaveAsync(MilitantContent militantContent);
        //update
        Task<SaveMilitantContentResponse> UpdateAsync(int id, MilitantContent militantContent);
        //delete
        Task<MilitantContentResponse> DeleteAsync(int id);
    }
}
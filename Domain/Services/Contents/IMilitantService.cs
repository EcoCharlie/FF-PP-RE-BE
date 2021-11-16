using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Contents
{
    public interface IMilitantService
    {
        //get
        Task<IEnumerable<Militant>> ListAsync();
        //post
        Task<SaveMilitantResponse> SaveAsync(Militant militant);
        //update
        Task<SaveMilitantResponse> UpdateAsync(int id, Militant militant);
        //delete
        Task<MilitantResponse> DeleteAsync(int id);
    }
}
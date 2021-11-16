using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Contents
{
    public interface IMilitantTypeService
    {
        //get
        Task<IEnumerable<MilitantType>> ListAsync();
        //post
        Task<SaveMilitantTypeResponse> SaveAsync(MilitantType militantType);
        //update
        Task<SaveMilitantTypeResponse> UpdateAsync(int id, MilitantType militantType);
        //delete
        Task<MilitantTypeResponse> DeleteAsync(int id);
    }
}
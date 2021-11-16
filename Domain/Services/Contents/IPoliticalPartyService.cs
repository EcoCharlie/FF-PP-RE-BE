using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;

namespace PiensaPeruAPIWeb.Domain.Services.Contents
{
    public interface IPoliticalPartyService
    {
        //get
        Task<IEnumerable<PoliticalParty>> ListAsync();
        //post
        Task<SavePoliticalPartyResponse> SaveAsync(PoliticalParty politicalParty);
        //update
        Task<SavePoliticalPartyResponse> UpdateAsync(int id, PoliticalParty politicalParty);
        //delete
        Task<PoliticalPartyResponse> DeleteAsync(int id);
    }
}
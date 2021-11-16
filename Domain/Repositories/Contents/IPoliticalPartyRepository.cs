using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;

namespace PiensaPeruAPIWeb.Domain.Repositories.Contents
{
    public interface IPoliticalPartyRepository
    {
        //get
        Task<IEnumerable<PoliticalParty>> ListAsync();
        //post
        Task AddAsync(PoliticalParty politicalParty);
        //update
        Task<PoliticalParty> FindByIdAsync(int id);
        void Update(PoliticalParty politicalParty);
        //delete
        void Remove(PoliticalParty politicalParty);
    }
}
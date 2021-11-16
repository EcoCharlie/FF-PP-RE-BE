using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Contents
{
    public class PoliticalPartyRepository: BaseRepository, IPoliticalPartyRepository
    {
        public PoliticalPartyRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<PoliticalParty>> ListAsync()
        {
            return await _context.PoliticalParties.ToListAsync();
        }
        //post
        public async Task AddAsync(PoliticalParty politicalParty)
        {
            await _context.AddAsync(politicalParty);
        }
        //update
        public async Task<PoliticalParty> FindByIdAsync(int id)
        {
            return await _context.PoliticalParties.FindAsync(id);
        }
        public async void Update(PoliticalParty politicalParty)
        {
            _context.Update(politicalParty);
        }
        //delete
        public async void Remove(PoliticalParty politicalParty)
        {
            _context.Remove(politicalParty);
        }
    }
}
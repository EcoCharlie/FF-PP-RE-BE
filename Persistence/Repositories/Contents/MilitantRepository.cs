using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Contents
{
    public class MilitantRepository : BaseRepository, IMilitantRepository
    {
        public MilitantRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<Militant>> ListAsync()
        {
            return await _context.Militants.ToListAsync();
        }
        //post
        public async Task AddAsync(Militant militant)
        {
            await _context.AddAsync(militant);
        }
        //update
        public async Task<Militant> FindByIdAsync(int id)
        {
            return await _context.Militants.FindAsync(id);
        }

        public void Update(Militant militant)
        {
            _context.Update(militant);
        }
        //remove
        public void Remove(Militant militant)
        {
            _context.Remove(militant);
        }
    }
}
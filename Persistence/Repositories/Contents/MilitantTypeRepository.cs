using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Contents
{
    public class MilitantTypeRepository : BaseRepository, IMilitantTypeRepository
    {

        public MilitantTypeRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<MilitantType>> ListAsync()
        {
            return await _context.MilitantTypes.ToListAsync();
        }
        //post
        public async Task AddAsync(MilitantType militantType)
        {
            await _context.AddAsync(militantType);
        }
        //update
        public async Task<MilitantType> FindByIdAsync(int id)
        {
            return await _context.MilitantTypes.FindAsync(id);
        }
        public async void Update(MilitantType militantType)
        {
            _context.Update(militantType);
        }
        //delete
        public async void Remove(MilitantType militantType)
        {
            _context.Remove(militantType);
        }
    }
}
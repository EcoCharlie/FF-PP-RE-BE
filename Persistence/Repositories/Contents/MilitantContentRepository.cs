using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Contents
{
    public class MilitantContentRepository : BaseRepository, IMilitantContentRepository
    {

        public MilitantContentRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<MilitantContent>> ListAsync()
        {
            return await _context.MilitantContents.ToListAsync();
        }
        //post
        public async Task AddAsync(MilitantContent militantContent)
        {
            await _context.AddAsync(militantContent);
        }
        //update
        public async Task<MilitantContent> FindByIdAsync(int id)
        {
            return await _context.MilitantContents.FindAsync(id);
        }
        public async void Update(MilitantContent militantContent)
        {
            _context.Update(militantContent);
        }
        //delete
        public async void Remove(MilitantContent militantContent)
        {
            _context.Remove(militantContent);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Contents
{
    public class ContentRepository : BaseRepository, IContentRepository
    {
        public ContentRepository(AppDbContext context) : base(context)
        {
        }
        //Get
        public async Task<IEnumerable<Content>> ListAsync()
        {
            return await _context.Contents.ToListAsync();
        }
        //post
        public async Task AddAsync(Content content)
        {
            await _context.AddAsync(content);
        }
        //update
        public async Task<Content> FindByIdAsync(int id)
        {
            return await _context.Contents.FindAsync(id);
        }
        public void Update(Content content)
        { 
            _context.Update(content);
        }
        //delete
        public void Remove(Content content)
        {
            _context.Remove(content);
        }
    }
}
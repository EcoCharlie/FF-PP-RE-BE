using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Contents
{
    public class PeriodRepository : BaseRepository, IPeriodRepository
    {
        public PeriodRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<Period>> ListAsync()
        {
            return await _context.Periods.ToListAsync();
        }
        //post
        public async Task AddAsync(Period period)
        {
            await _context.AddAsync(period);
        }
        //update
        public async Task<Period> FindByIdAsync(int id)
        {
            return await _context.Periods.FindAsync(id);
        }
        public async void Update(Period period)
        {
            _context.Update(period);
        }
        //delete
        public async void Remove(Period period)
        {
            _context.Remove(period);
        }
    }
}
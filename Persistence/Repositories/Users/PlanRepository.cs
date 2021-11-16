using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Repositories.Users;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Users
{
    public class PlanRepository : BaseRepository, IPlanRepository
    {
        //get
        public PlanRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _context.Plans.ToListAsync();
        }
        //post
        public async Task AddAsync(Plan plan)
        {
            await _context.AddAsync(plan);
        }
        //update
        public async Task<Plan> FindByIdAsync(int id)
        {
            return await _context.Plans.FindAsync(id);
        }
        public async void Update(Plan plan)
        {
            _context.Update(plan);
        }
        //delete
        public void Remove(Plan plan)
        {
            _context.Remove(plan);
        }
    }
}

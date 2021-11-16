using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Repositories.Users;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Users
{
    public class UserPlanRepository : BaseRepository, IUserPlanRepository
    {
        //get
        public UserPlanRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<UserPlan>> ListAsync()
        {
            return await _context.UserPlans.ToListAsync();
        }
        //post
        public async Task AddAsync(UserPlan userPlan)
        {
            await _context.AddAsync(userPlan);
        }
        //update
        public async Task<UserPlan> FindByIdAsync(int id)
        {
            return await _context.UserPlans.FindAsync(id);
        }
        public async void Update(UserPlan userPlan)
        {
            _context.Update(userPlan);
        }
        //delete
        public void Remove(UserPlan userPlan)
        {
            _context.Remove(userPlan);
        }
    }
}

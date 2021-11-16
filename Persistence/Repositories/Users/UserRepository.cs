using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Repositories.Users;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories.Users
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        //get
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        //post
        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
        }
        //update
        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async void Update(User user)
        {
            _context.Update(user);
        }
        //delete
        public void Remove(User user)
        {
            _context.Remove(user);
        }
    }
}

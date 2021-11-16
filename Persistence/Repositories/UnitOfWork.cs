using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Repositories;
using PiensaPeruAPIWeb.Persistence.Contexts;

namespace PiensaPeruAPIWeb.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompletedAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
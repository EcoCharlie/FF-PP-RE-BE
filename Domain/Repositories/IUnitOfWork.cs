using System.Threading.Tasks;

namespace PiensaPeruAPIWeb.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompletedAsync();
    }
}
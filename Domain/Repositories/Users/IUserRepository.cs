using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Repositories.Users
{
    public interface IUserRepository
    {
        //Get
        Task<IEnumerable<User>> ListAsync();
        //post
        Task AddAsync(User user);
        //Update
        Task<User> FindByIdAsync(int id);
        void Update(User user);
        //delete
        void Remove(User user);
    }
}

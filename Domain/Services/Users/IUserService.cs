using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Services.Communication.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Users
{
    public interface IUserService
    {
        //Get
        Task<IEnumerable<User>> ListAsync();
        //Post
        Task<SaveUserResponse> SaveAsync(User user);
        //UpdateOrModify
        Task<SaveUserResponse> UpdateAsync(int id, User user);
        //delete
        Task<UserResponse> DeleteAsync(int id);
    }
}

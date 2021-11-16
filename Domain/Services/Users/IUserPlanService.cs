using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Services.Communication.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Users
{
    public interface IUserPlanService
    {
        //Get
        Task<IEnumerable<UserPlan>> ListAsync();
        //Post
        Task<SaveUserPlanResponse> SaveAsync(UserPlan userplan);
        //UpdateOrModify
        Task<SaveUserPlanResponse> UpdateAsync(int id, UserPlan userplan);
        //delete
        Task<UserPlanResponse> DeleteAsync(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Services.Communication.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Users
{
    public interface IPlanService
    {
        //Get
        Task<IEnumerable<Plan>> ListAsync();
        //Post
        Task<SavePlanResponse> SaveAsync(Plan plan);
        //UpdateOrModify
        Task<SavePlanResponse> UpdateAsync(int id, Plan plan);
        //delete
        Task<PlanResponse> DeleteAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Repositories.Users
{
    public interface IUserPlanRepository
    {
        //Get
        Task<IEnumerable<UserPlan>> ListAsync();
        //post
        Task AddAsync(UserPlan userPlan);
        //Update
        Task<UserPlan> FindByIdAsync(int id);
        void Update(UserPlan userPlan);
        //delete
        void Remove(UserPlan userPlan);
    }
}

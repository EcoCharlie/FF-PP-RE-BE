using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Repositories.Users
{
    public interface IPlanRepository
    {
        //Get
        Task<IEnumerable<Plan>> ListAsync();
        //post
        Task AddAsync(Plan plan);
        //Update
        Task<Plan> FindByIdAsync(int id);
        void Update(Plan plan);
        //delete
        void Remove(Plan plan);
    }
}

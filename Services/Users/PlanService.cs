using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Repositories;
using PiensaPeruAPIWeb.Domain.Repositories.Users;
using PiensaPeruAPIWeb.Domain.Services.Communication.Users;
using PiensaPeruAPIWeb.Domain.Services.Users;

namespace PiensaPeruAPIWeb.Services.Users
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public PlanService(IPlanRepository plan, IUnitOfWork unitOfWork)
        {
            _planRepository = plan;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _planRepository.ListAsync();
        }
        //post
        public async Task<SavePlanResponse> SaveAsync(Plan plan)
        {
            try
            {
                await _planRepository.AddAsync(plan);
                await _unitOfWork.CompletedAsync();

                return new SavePlanResponse(plan);
            }
            catch (Exception e)
            {
                return new SavePlanResponse($"An error occured while saving the plan: ${e.Message}");
            }
        }
        //update
        public async Task<SavePlanResponse> UpdateAsync(int id, Plan plan)
        {
            var existingPlan = await _planRepository.FindByIdAsync(id);
            if (existingPlan == null)
                return new SavePlanResponse("Plan not found.");
            
            existingPlan.Description = plan.Description;
            existingPlan.Name = plan.Name;  
            existingPlan.Price = plan.Price;
            
            try
            {
                _planRepository.Update(existingPlan);
                await _unitOfWork.CompletedAsync();

                return new SavePlanResponse(existingPlan);
            }
            catch (Exception e)
            {
                return new SavePlanResponse($"An error occured while updating the plan: ${ e.Message }");
            }
        }
        //delete
        public async Task<PlanResponse> DeleteAsync(int id)
        {
            var existingPlan = await _planRepository.FindByIdAsync(id);
            if (existingPlan == null) return new PlanResponse("Plan no found.");
            try
            {
                _planRepository.Remove(existingPlan);
                await _unitOfWork.CompletedAsync();

                return new PlanResponse(existingPlan);
            }
            catch (Exception e)
            {
                return new PlanResponse($"An error occured while delete the plan: ${e.Message}");
            }
        }
    }
}

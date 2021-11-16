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
    public class UserPlanService : IUserPlanService
    {
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UserPlanService(IUserPlanRepository userPlan, IUnitOfWork unitOfWork)
        {
            _userPlanRepository = userPlan;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<UserPlan>> ListAsync()
        {
            return await _userPlanRepository.ListAsync();
        }
        //post
        public async Task<SaveUserPlanResponse> SaveAsync(UserPlan userPlan)
        {
            try
            {
                await _userPlanRepository.AddAsync(userPlan);
                await _unitOfWork.CompletedAsync();

                return new SaveUserPlanResponse(userPlan);
            }
            catch (Exception e)
            {
                return new SaveUserPlanResponse($"An error occured while saving the userPlan: ${e.Message}");
            }
        }
        //update
        public async Task<SaveUserPlanResponse> UpdateAsync(int id, UserPlan userPlan)
        {
            var existingUserPlan = await _userPlanRepository.FindByIdAsync(id);
            if (existingUserPlan == null)
                return new SaveUserPlanResponse("UserPlan not found.");

            existingUserPlan.ActivatedDate = userPlan.ActivatedDate;
            
            try
            {
                _userPlanRepository.Update(existingUserPlan);
                await _unitOfWork.CompletedAsync();

                return new SaveUserPlanResponse(existingUserPlan);
            }
            catch (Exception e)
            {
                return new SaveUserPlanResponse($"An error occured while updating the userPlan: ${ e.Message }");
            }
        }
        //delete
        public async Task<UserPlanResponse> DeleteAsync(int id)
        {
            var existingUserPlan = await _userPlanRepository.FindByIdAsync(id);
            if (existingUserPlan == null) return new UserPlanResponse("UserPlan no found.");
            try
            {
                _userPlanRepository.Remove(existingUserPlan);
                await _unitOfWork.CompletedAsync();

                return new UserPlanResponse(existingUserPlan);
            }
            catch (Exception e)
            {
                return new UserPlanResponse($"An error occured while delete the userPlan: ${e.Message}");
            }
        }
    }
}

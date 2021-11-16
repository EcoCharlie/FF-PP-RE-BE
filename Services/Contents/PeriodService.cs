using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;
using PiensaPeruAPIWeb.Domain.Services.Contents;

namespace PiensaPeruAPIWeb.Services.Contents
{
    public class PeriodService : IPeriodService
    {
        private readonly IPeriodRepository _periodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PeriodService(IPeriodRepository periodRepository, IUnitOfWork unitOfWork)
        {
            _periodRepository = periodRepository;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<Period>> ListAsync()
        {
            return await _periodRepository.ListAsync();
        }
        //post
        public async Task<SavePeriodResponse> SaveAsync(Period period)
        {
            try
            {
                await _periodRepository.AddAsync(period);
                await _unitOfWork.CompletedAsync();

                return new SavePeriodResponse(period);
            }
            catch (Exception e)
            {
                return new SavePeriodResponse($"An error occured while saving the period: ${e.Message}");
            }
        }
        //update
        public async Task<SavePeriodResponse> UpdateAsync(int id, Period period)
        {
            var existingPeriod = await _periodRepository.FindByIdAsync(id);
            if (existingPeriod == null)
                return new SavePeriodResponse("Period not found.");

            existingPeriod.StartDate = period.StartDate;
            existingPeriod.EndDate = period.EndDate;
            existingPeriod.OriginOfChange = period.OriginOfChange;
            try
            {
                _periodRepository.Update(existingPeriod);
                await _unitOfWork.CompletedAsync();

                return new SavePeriodResponse(existingPeriod);
            }
            catch (Exception e)
            {
                return new SavePeriodResponse($"An error occured while updating the period: ${ e.Message }");
            }
        }
        //delete
        public async Task<PeriodResponse> DeleteAsync(int id)
        {
            var existingPeriod = await _periodRepository.FindByIdAsync(id);
            if (existingPeriod == null) return new PeriodResponse("Period no found.");
            try
            {
                _periodRepository.Remove(existingPeriod);
                await _unitOfWork.CompletedAsync();

                return new PeriodResponse(existingPeriod);
            }
            catch (Exception e)
            {
                return new PeriodResponse($"An error occured while delete the period: ${e.Message}");
            }
        }
    }
}
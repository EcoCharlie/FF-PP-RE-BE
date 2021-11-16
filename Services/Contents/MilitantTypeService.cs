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
    public class MilitantTypeService : IMilitantTypeService
    {
        private readonly IMilitantTypeRepository _militantTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MilitantTypeService(IMilitantTypeRepository militantTypeRepository, IUnitOfWork unitOfWork)
        {
            _militantTypeRepository = militantTypeRepository;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<MilitantType>> ListAsync()
        {
            return await _militantTypeRepository.ListAsync();
        }
        //post
        public async Task<SaveMilitantTypeResponse> SaveAsync(MilitantType militantType)
        {
            try
            {
                await _militantTypeRepository.AddAsync(militantType);
                await _unitOfWork.CompletedAsync();

                return new SaveMilitantTypeResponse(militantType);
            }
            catch (Exception e)
            {
                return new SaveMilitantTypeResponse($"An error occured while saving the militantType: ${e.Message}");
            }
        }
        //update
        public async Task<SaveMilitantTypeResponse> UpdateAsync(int id, MilitantType militantType)
        {
            var existingMilitantType = await _militantTypeRepository.FindByIdAsync(id);
            if (existingMilitantType == null)
                return new SaveMilitantTypeResponse("MilitantType not found.");

            existingMilitantType.Type = militantType.Type;
            try
            {
                _militantTypeRepository.Update(existingMilitantType);
                await _unitOfWork.CompletedAsync();

                return new SaveMilitantTypeResponse(existingMilitantType);
            }
            catch (Exception e)
            {
                return new SaveMilitantTypeResponse($"An error occured while updating the militantType: ${ e.Message }");
            }
        }
        //delete
        public async Task<MilitantTypeResponse> DeleteAsync(int id)
        {
            var existingMilitantType = await _militantTypeRepository.FindByIdAsync(id);
            if (existingMilitantType == null) return new MilitantTypeResponse("MilitantType no found.");
            try
            {
                _militantTypeRepository.Remove(existingMilitantType);
                await _unitOfWork.CompletedAsync();

                return new MilitantTypeResponse(existingMilitantType);
            }
            catch (Exception e)
            {
                return new MilitantTypeResponse($"An error occured while delete the militantType: ${e.Message}");
            }
        }
    }
}
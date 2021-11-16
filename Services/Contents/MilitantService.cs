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
    public class MilitantService : IMilitantService
    {
        private readonly IMilitantRepository _militantRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MilitantService(IMilitantRepository militantRepository, IUnitOfWork unitOfWork)
        {
            _militantRepository = militantRepository;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<Militant>> ListAsync()
        {
            return await _militantRepository.ListAsync();
        }
        //post
        public async Task<SaveMilitantResponse> SaveAsync(Militant militant)
        {
            try
            {
                await _militantRepository.AddAsync(militant);
                await _unitOfWork.CompletedAsync();

                return new SaveMilitantResponse(militant);
            }
            catch (Exception e)
            {
                return new SaveMilitantResponse($"An error occured while saving the militant: ${e.Message}");
            }
        }
        //update
        public async Task<SaveMilitantResponse> UpdateAsync(int id, Militant militant)
        {
            var existingMilitant = await _militantRepository.FindByIdAsync(id);
            if (existingMilitant == null)
                return new SaveMilitantResponse("Militant not found.");

            existingMilitant.FirstName = militant.FirstName;
            existingMilitant.LastName = militant.LastName;
            existingMilitant.BirthDate = militant.BirthDate;
            existingMilitant.BirthPlace = militant.BirthPlace;
            existingMilitant.Profession = militant.Profession;
            existingMilitant.PictureLink = militant.PictureLink;
            existingMilitant.IsPresident = militant.IsPresident;
            try
            {
                _militantRepository.Update(existingMilitant);
                await _unitOfWork.CompletedAsync();

                return new SaveMilitantResponse(existingMilitant);
            }
            catch (Exception e)
            {
                return new SaveMilitantResponse($"An error occured while updating the militant: ${ e.Message }");
            }
        }
        //delete
        public async Task<MilitantResponse> DeleteAsync(int id)
        {
            var existingMilitant = await _militantRepository.FindByIdAsync(id);
            if (existingMilitant == null) return new MilitantResponse("Militant no found.");
            try
            {
                _militantRepository.Remove(existingMilitant);
                await _unitOfWork.CompletedAsync();

                return new MilitantResponse(existingMilitant);
            }
            catch (Exception e)
            {
                return new MilitantResponse($"An error occured while delete the militant: ${e.Message}");
            }
        }
    }
}
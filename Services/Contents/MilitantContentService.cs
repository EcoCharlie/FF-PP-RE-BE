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
    public class MilitantContentService : IMilitantContentService
    {
        private readonly IMilitantContentRepository _militantContentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MilitantContentService(IMilitantContentRepository militantContentRepository, IUnitOfWork unitOfWork)
        {
            _militantContentRepository = militantContentRepository;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<MilitantContent>> ListAsync()
        {
            return await _militantContentRepository.ListAsync();
        }
        //post
        public async Task<SaveMilitantContentResponse> SaveAsync(MilitantContent militantContent)
        {
            try
            {
                await _militantContentRepository.AddAsync(militantContent);
                await _unitOfWork.CompletedAsync();

                return new SaveMilitantContentResponse(militantContent);
            }
            catch (Exception e)
            {
                return new SaveMilitantContentResponse($"An error occured while saving the militantContent: ${e.Message}");
            }
        }
        //update
        public async Task<SaveMilitantContentResponse> UpdateAsync(int id, MilitantContent militantContent)
        {
            var existingMilitantContent = await _militantContentRepository.FindByIdAsync(id);
            if (existingMilitantContent == null)
                return new SaveMilitantContentResponse("MilitantContent not found.");
            
            //existingMilitantContent.Active = militantContent.;
            try
            {
                _militantContentRepository.Update(existingMilitantContent);
                await _unitOfWork.CompletedAsync();

                return new SaveMilitantContentResponse(existingMilitantContent);
            }
            catch (Exception e)
            {
                return new SaveMilitantContentResponse($"An error occured while updating the militantContent: ${ e.Message }");
            }
        }
        //delete
        public async Task<MilitantContentResponse> DeleteAsync(int id)
        {
            var existingMilitantContent = await _militantContentRepository.FindByIdAsync(id);
            if (existingMilitantContent == null) return new MilitantContentResponse("MilitantContent no found.");
            try
            {
                _militantContentRepository.Remove(existingMilitantContent);
                await _unitOfWork.CompletedAsync();

                return new MilitantContentResponse(existingMilitantContent);
            }
            catch (Exception e)
            {
                return new MilitantContentResponse($"An error occured while delete the militantContent: ${e.Message}");
            }
        }
    }
}
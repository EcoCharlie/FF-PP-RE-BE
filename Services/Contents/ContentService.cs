using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Repositories;
using PiensaPeruAPIWeb.Domain.Repositories.Contents;
using PiensaPeruAPIWeb.Domain.Services.Communication.Contents;
using PiensaPeruAPIWeb.Domain.Services.Contents;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Services.Contents
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ContentService(IContentRepository contentRepository, IUnitOfWork unitOfWork)
        {
            _contentRepository = contentRepository;
            _unitOfWork = unitOfWork;
        }
        //Get
        public async Task<IEnumerable<Content>> ListAsync()
        {
            return await _contentRepository.ListAsync();
        }
        //post
        public async Task<SaveContentResponse> SaveAsync(Content content)
        {
            try
            {
                await _contentRepository.AddAsync(content);
                await _unitOfWork.CompletedAsync();

                return new SaveContentResponse(content);
            }
            catch (Exception e)
            {
                return new SaveContentResponse($"An error occured while saving the content: ${e.Message}");
            }
        }
        //update
        public async Task<SaveContentResponse> UpdateAsync(int id, Content content)
        {
            var existingContent = await _contentRepository.FindByIdAsync(id);
            if (existingContent == null)
                return new SaveContentResponse("Content not found.");
            
            existingContent.Active = content.Active;
            try
            {
                _contentRepository.Update(existingContent);
                await _unitOfWork.CompletedAsync();

                return new SaveContentResponse(existingContent);
            }
            catch (Exception e)
            {
                return new SaveContentResponse($"An error occured while updating the content: ${ e.Message }");
            }
        }
        //delete
        public async Task<ContentResponse> DeleteAsync(int id)
        {
            var existingContent = await _contentRepository.FindByIdAsync(id);
            if (existingContent == null) return new ContentResponse("Content no found.");
            try
            {
                _contentRepository.Remove(existingContent);
                await _unitOfWork.CompletedAsync();

                return new ContentResponse(existingContent);
            }
            catch (Exception e)
            {
                return new ContentResponse($"An error occured while delete the content: ${e.Message}");
            }
        }


    }
}
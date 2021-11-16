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
    public class PoliticalPartyService : IPoliticalPartyService
    {
        private readonly IPoliticalPartyRepository _politicalPartyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PoliticalPartyService(IPoliticalPartyRepository politicalPartyRepository, IUnitOfWork unitOfWork)
        {
            _politicalPartyRepository = politicalPartyRepository;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<PoliticalParty>> ListAsync()
        {
            return await _politicalPartyRepository.ListAsync();
        }
        //post
        public async Task<SavePoliticalPartyResponse> SaveAsync(PoliticalParty politicalParty)
        {
            try
            {
                await _politicalPartyRepository.AddAsync(politicalParty);
                await _unitOfWork.CompletedAsync();

                return new SavePoliticalPartyResponse(politicalParty);
            }
            catch (Exception e)
            {
                return new SavePoliticalPartyResponse($"An error occured while saving the politicalParty: ${e.Message}");
            }
        }
        //update
        public async Task<SavePoliticalPartyResponse> UpdateAsync(int id, PoliticalParty politicalParty)
        {
            var existingPoliticalParty = await _politicalPartyRepository.FindByIdAsync(id);
            if (existingPoliticalParty == null)
                return new SavePoliticalPartyResponse("PoliticalParty not found.");

            existingPoliticalParty.PoliticalPartyName = politicalParty.PoliticalPartyName;
            existingPoliticalParty.PresidentName = politicalParty.PresidentName;
            existingPoliticalParty.FoundationDate = politicalParty.FoundationDate;
            existingPoliticalParty.Ideology = politicalParty.Ideology;
            existingPoliticalParty.Position = politicalParty.Position;
            existingPoliticalParty.PictureLink = politicalParty.PictureLink;
            try
            {
                _politicalPartyRepository.Update(existingPoliticalParty);
                await _unitOfWork.CompletedAsync();

                return new SavePoliticalPartyResponse(existingPoliticalParty);
            }
            catch (Exception e)
            {
                return new SavePoliticalPartyResponse($"An error occured while updating the politicalParty: ${ e.Message }");
            }
        }
        //delete
        public async Task<PoliticalPartyResponse> DeleteAsync(int id)
        {
            var existingPoliticalParty = await _politicalPartyRepository.FindByIdAsync(id);
            if (existingPoliticalParty == null) return new PoliticalPartyResponse("PoliticalParty no found.");
            try
            {
                _politicalPartyRepository.Remove(existingPoliticalParty);
                await _unitOfWork.CompletedAsync();

                return new PoliticalPartyResponse(existingPoliticalParty);
            }
            catch (Exception e)
            {
                return new PoliticalPartyResponse($"An error occured while delete the politicalParty: ${e.Message}");
            }
        }
    }
}
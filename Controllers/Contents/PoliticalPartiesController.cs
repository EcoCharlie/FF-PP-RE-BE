using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PiensaPeruAPIWeb.Domain.Models.Contents;
using PiensaPeruAPIWeb.Domain.Services.Contents;
using PiensaPeruAPIWeb.Extensions;
using PiensaPeruAPIWeb.Resources.Contents;

namespace PiensaPeruAPIWeb.Controllers.Contents
{
    [Route("api/v1/[controller]")]
    public class PoliticalPartiesController : ControllerBase
    {
         private readonly IPoliticalPartyService _politicalPartyService;
        private readonly IMapper _mapper;

        public PoliticalPartiesController(IPoliticalPartyService politicalPartyService, IMapper mapper)
        {
            _politicalPartyService = politicalPartyService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PoliticalPartyResource>> GetAllList()
        {
            var politicalParties = await _politicalPartyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<PoliticalParty>, IEnumerable<PoliticalPartyResource>>(politicalParties);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePoliticalPartyResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var politicalParties = _mapper.Map<SavePoliticalPartyResource, PoliticalParty>(resource);
            var result = await _politicalPartyService.SaveAsync(politicalParties);

            if (!result.Success)
                return BadRequest(result.Message);

            var politicalPartyResource = _mapper.Map<PoliticalParty, PoliticalPartyResource>(result.PoliticalParty);

            return Ok(politicalPartyResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePoliticalPartyResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            
            var politicalParty = _mapper.Map<SavePoliticalPartyResource, PoliticalParty>(resource);
            var result = await _politicalPartyService.UpdateAsync(id, politicalParty);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var politicalPartyResource = _mapper.Map<PoliticalParty, PoliticalPartyResource>(result.PoliticalParty);

            return Ok(politicalPartyResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _politicalPartyService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var politicalPartyResource = _mapper.Map<PoliticalParty, PoliticalPartyResource>(result.PoliticalParty);

            return Ok(politicalPartyResource);
        }
    }
}
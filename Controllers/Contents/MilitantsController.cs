using System.Collections;
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
    [Route("/api/v1/[controller]")]
    public class MilitantsController : ControllerBase
    {
        private readonly IMilitantService _militantService;
        private readonly IMapper _mapper;

        public MilitantsController(IMilitantService militantService, IMapper mapper)
        {
            _militantService = militantService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<MilitantResource>> GetAllList()
        {
            var militants = await _militantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Militant>, IEnumerable<MilitantResource>>(militants);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMilitantResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var militants = _mapper.Map<SaveMilitantResource, Militant>(resource);
            var result = await _militantService.SaveAsync(militants);

            if (!result.Success)
                return BadRequest(result.Message);

            var militantResource = _mapper.Map<Militant, MilitantResource>(result.Militant);

            return Ok(militantResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMilitantResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            
            var militant = _mapper.Map<SaveMilitantResource, Militant>(resource);
            var result = await _militantService.UpdateAsync(id, militant);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var militantResource = _mapper.Map<Militant, MilitantResource>(result.Militant);

            return Ok(militantResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _militantService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var militantResource = _mapper.Map<Militant, MilitantResource>(result.Militant);

            return Ok(militantResource);
        }
    }
}
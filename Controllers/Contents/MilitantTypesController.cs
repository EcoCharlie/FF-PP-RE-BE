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
    public class MilitantTypesController : ControllerBase
    {
        private readonly IMilitantTypeService _militantTypeService;
        private readonly IMapper _mapper;
        
        public MilitantTypesController(IMilitantTypeService militantTypeService, IMapper mapper)
        {
            _militantTypeService = militantTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<MilitantTypeResource>> GetAllSync()
        {
            var militantTypes = await _militantTypeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<MilitantType>, IEnumerable<MilitantTypeResource>>(militantTypes);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMilitantTypeResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var militantType = _mapper.Map<SaveMilitantTypeResource, MilitantType>(resource);
            var result = await _militantTypeService.SaveAsync(militantType);

            if (!result.Success)
                return BadRequest(result.Message);

            var militantTypeResource = _mapper.Map<MilitantType, MilitantTypeResource>(result.MilitantType);

            return Ok(militantTypeResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMilitantTypeResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            
            var militantType = _mapper.Map<SaveMilitantTypeResource, MilitantType>(resource);
            var result = await _militantTypeService.UpdateAsync(id, militantType);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var militantTypeResource = _mapper.Map<MilitantType, MilitantTypeResource>(result.MilitantType);

            return Ok(militantTypeResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _militantTypeService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var militantTypeResource = _mapper.Map<MilitantType,MilitantTypeResource>(result.MilitantType);

            return Ok(militantTypeResource);
        }
    }
}
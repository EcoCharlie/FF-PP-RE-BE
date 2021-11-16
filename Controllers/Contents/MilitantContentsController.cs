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
    public class MilitantContentsController : ControllerBase
    {
        private readonly IMilitantContentService _militantContentService;
        private readonly IMapper _mapper;
        
        public MilitantContentsController(IMilitantContentService militantContentService, IMapper mapper)
        {
            _militantContentService = militantContentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<MilitantContentResource>> GetAllSync()
        {
            var militantContents = await _militantContentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<MilitantContent>, IEnumerable<MilitantContentResource>>(militantContents);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMilitantContentResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var militantContent = _mapper.Map<SaveMilitantContentResource, MilitantContent>(resource);
            var result = await _militantContentService.SaveAsync(militantContent);

            if (!result.Success)
                return BadRequest(result.Message);

            var militantContentResource = _mapper.Map<MilitantContent, SaveMilitantContentResource>(result.MilitantContent);

            return Ok(militantContentResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMilitantContentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            
            var militantContent = _mapper.Map<SaveMilitantContentResource, MilitantContent>(resource);
            var result = await _militantContentService.UpdateAsync(id, militantContent);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var militantContentResource = _mapper.Map<MilitantContent, SaveMilitantContentResource>(result.MilitantContent);

            return Ok(militantContentResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _militantContentService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var militantContentResource = _mapper.Map<MilitantContent, SaveMilitantContentResource>(result.MilitantContent);

            return Ok(militantContentResource);
        }
    }
}
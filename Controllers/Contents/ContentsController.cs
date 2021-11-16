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
    [Route("api/v1/[controller]")]
    public class ContentsController : ControllerBase
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;
        
        public ContentsController(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ContentResource>> GetAllSync()
        {
            var contents = await _contentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Content>, IEnumerable<ContentResource>>(contents);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveContentResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var contents = _mapper.Map<SaveContentResource, Content>(resource);
            var result = await _contentService.SaveAsync(contents);

            if (!result.Success)
                return BadRequest(result.Message);

            var contentResource = _mapper.Map<Content, ContentResource>(result.Content);

            return Ok(contentResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveContentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            
            var content = _mapper.Map<SaveContentResource, Content>(resource);
            var result = await _contentService.UpdateAsync(id, content);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var contentResource = _mapper.Map<Content, ContentResource>(result.Content);

            return Ok(contentResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _contentService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var contentResource = _mapper.Map<Content, ContentResource>(result.Content);

            return Ok(contentResource);
        }
    }
}
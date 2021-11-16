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
    public class PeriodsController : ControllerBase
    {
        private readonly IPeriodService _periodService;
        private readonly IMapper _mapper;

        public PeriodsController(IPeriodService periodService, IMapper mapper)
        {
            _periodService = periodService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PeriodResource>> GetAllList()
        {
            var periods = await _periodService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Period>, IEnumerable<PeriodResource>>(periods);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePeriodResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var periods = _mapper.Map<SavePeriodResource, Period>(resource);
            var result = await _periodService.SaveAsync(periods);

            if (!result.Success)
                return BadRequest(result.Message);

            var periodResource = _mapper.Map<Period, PeriodResource>(result.Period);

            return Ok(periodResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePeriodResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            
            var period = _mapper.Map<SavePeriodResource, Period>(resource);
            var result = await _periodService.UpdateAsync(id, period);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var periodResource = _mapper.Map<Period, PeriodResource>(result.Period);

            return Ok(periodResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _periodService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var periodResource = _mapper.Map<Period, PeriodResource>(result.Period);

            return Ok(periodResource);
        }
    }
}
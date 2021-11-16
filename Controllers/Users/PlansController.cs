using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PiensaPeruAPIWeb.Domain.Models.Users;
using PiensaPeruAPIWeb.Domain.Services.Users;
using PiensaPeruAPIWeb.Extensions;
using PiensaPeruAPIWeb.Resources.Users;

namespace PiensaPeruAPIWeb.Controllers.Users
{
    [Route("/api/v1/[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PlansController(IPlanService plan, IMapper mapper)
        {
            _planService = plan;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PlanResource>> GetAllSync()
        {
            var plans = await _planService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanResource>>(plans);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var plans = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.SaveAsync(plans);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Plan);

            return Ok(planResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.UpdateAsync(id, plan);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Plan);

            return Ok(planResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _planService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Plan);

            return Ok(planResource);
        }
    }
}

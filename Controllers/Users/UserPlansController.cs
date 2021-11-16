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
    public class UserPlansController : ControllerBase
    {
        private readonly IUserPlanService _userPlanService;
        private readonly IMapper _mapper;

        public UserPlansController(IUserPlanService plan, IMapper mapper)
        {
            _userPlanService = plan;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserPlanResource>> GetAllSync()
        {
            var userPlans = await _userPlanService.ListAsync();
            var resources = _mapper.Map<IEnumerable<UserPlan>, IEnumerable<UserPlanResource>>(userPlans);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserPlanResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var userPlans = _mapper.Map<SaveUserPlanResource, UserPlan>(resource);
            var result = await _userPlanService.SaveAsync(userPlans);

            if (!result.Success)
                return BadRequest(result.Message);

            var userPlanResource = _mapper.Map<UserPlan, UserPlanResource>(result.UserPlan);

            return Ok(userPlanResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserPlanResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }

            var userPlan = _mapper.Map<SaveUserPlanResource, UserPlan>(resource);
            var result = await _userPlanService.UpdateAsync(id, userPlan);

            if (!result.Success)
                return BadRequest(result.Message);

            var userPlanResource = _mapper.Map<UserPlan, UserPlanResource>(result.UserPlan);

            return Ok(userPlanResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userPlanService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var userPlanResource = _mapper.Map<UserPlan, UserPlanResource>(result.UserPlan);

            return Ok(userPlanResource);
        }
    }
}

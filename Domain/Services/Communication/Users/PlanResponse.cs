using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Users
{
    public class PlanResponse : BaseResponse
    {
        public Plan Plan { get; set; }
        public PlanResponse(bool success, string message, Plan plan) : base(success, message)
        {
            Plan = plan;
        }
        public PlanResponse(Plan plan) : this(true, string.Empty, plan) { }

        public PlanResponse(string message) : this(false, message, null) { }
    }
}

using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Users
{
    public class SavePlanResponse : BaseResponse
    {
        public Plan Plan { get; private set; }
        public SavePlanResponse(bool success, string message, Plan plan) : base(success, message)
        {
            Plan = plan;
        }
        public SavePlanResponse(Plan plan) : this(true, string.Empty, plan) { }
        public SavePlanResponse(string message) : this(false, string.Empty, null) { }
    }
}

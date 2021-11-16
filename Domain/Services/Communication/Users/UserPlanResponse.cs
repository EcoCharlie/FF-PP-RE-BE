using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Users
{
    public class UserPlanResponse : BaseResponse
    {
        public UserPlan UserPlan { get; set; }
        public UserPlanResponse(bool success, string message, UserPlan userplan) : base(success, message)
        {
            UserPlan = userplan;
        }
        public UserPlanResponse(UserPlan userplan) : this(true, string.Empty, userplan) { }

        public UserPlanResponse(string message) : this(false, message, null) { }
    }
}

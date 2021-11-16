using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Users
{
    public class SaveUserPlanResponse : BaseResponse
    {
        public UserPlan UserPlan { get; private set; }
        public SaveUserPlanResponse(bool success, string message, UserPlan userplan) : base(success, message)
        {
            UserPlan = userplan;
        }
        public SaveUserPlanResponse(UserPlan userplan) : this(true, string.Empty, userplan) { }
        public SaveUserPlanResponse(string message) : this(false, string.Empty, null) { }
    }
}

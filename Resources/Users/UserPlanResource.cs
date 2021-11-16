using System;

namespace PiensaPeruAPIWeb.Resources.Users
{
    public class UserPlanResource
    {
        public int UserId { get; set; }
        public int PlanId { get; set; } 
        public DateTime ActivatedDate { get; set; }
    }
}

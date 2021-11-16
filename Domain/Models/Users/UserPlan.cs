using System;

namespace PiensaPeruAPIWeb.Domain.Models.Users
{
    public class UserPlan
    {
        public DateTime ActivatedDate { get; set; }
        
        //RelationShip-User
        public int UserId { get; set; }
        public User User { get; set; }
        
        //RelationShip-Plan
        public int PlanId { get; set; } 
        public Plan Plan { get; set; }
    }
}
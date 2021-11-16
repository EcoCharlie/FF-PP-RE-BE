using System.Collections.Generic;

namespace PiensaPeruAPIWeb.Domain.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        //RelationShip-UserPlan
        public IList<UserPlan> UserPlans { get; set; } = new List<UserPlan>();
    }
}
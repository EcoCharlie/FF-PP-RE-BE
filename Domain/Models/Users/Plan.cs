using System.Collections.Generic;

namespace PiensaPeruAPIWeb.Domain.Models.Users
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        //RelationShip-UserPlan
        public IList<UserPlan> UserPlans { get; set; } = new List<UserPlan>();
    }
}
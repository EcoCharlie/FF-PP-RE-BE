using PiensaPeruAPIWeb.Domain.Models.Users;

namespace PiensaPeruAPIWeb.Domain.Services.Communication.Users
{
    public class UserResponse : BaseResponse
    {
        public User User { get; set; }
        public UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }
        public UserResponse(User user) : this(true, string.Empty, user) { }

        public UserResponse(string message) : this(false, message, null) { }
    }
}

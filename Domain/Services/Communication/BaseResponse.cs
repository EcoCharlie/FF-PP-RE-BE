namespace PiensaPeruAPIWeb.Domain.Services.Communication
{
    public class BaseResponse
    {

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        

    }
}
namespace AdvertVisitService.API.Core.Domain.Models.Response.Base
{
    public class ApiBaseResponseModel<T> where T : new()
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string DetailMessage { get; set; }
        public T Data { get; set; }

        public ApiBaseResponseModel()
        {
            Success = false;
            Message = string.Empty;
            DetailMessage = string.Empty;
        }
    }
}

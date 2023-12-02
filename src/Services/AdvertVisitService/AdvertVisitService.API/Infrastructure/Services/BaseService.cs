namespace AdvertVisitService.API.Infrastructure.Services
{
    public class BaseService
    {
        protected readonly IConfiguration _configuration;

        public BaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}

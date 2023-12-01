using System.Reflection;
using VehicleAdverts.API.Infrastructure.Services;
using VehicleAdverts.API.Infrastructure.Services.Abstract;

namespace VehicleAdverts.API.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertsService, AdvertsService>();
            services.AddScoped<IAdvertVisitsService, AdvertVisitsService>();

            return services;
        }
    }
}

using AdvertVisitService.API.Infrastructure.Services;
using AdvertVisitService.API.Infrastructure.Services.Abstract;
using AdvertVisitService.API.IntegrationEvents.EventHandlers;
using AdvertVisitService.API.IntegrationEvents.Events;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;

namespace AdvertVisitService.API.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertVisitsService, AdvertVisitsService>();

            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new EventBusConfig()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "ConcatService",
                    EventBusType = EventBusType.RabbitMQ
                };

                return EventBusFactory.Create(config, sp);
            });

            services.AddScoped<AdvertVisitedIntegrationEventHandler>();

            return services;
        }

        public static IServiceProvider ConfigureSubscription(this IServiceProvider serviceProvider)
        {
            var eventBus = serviceProvider.GetRequiredService<IEventBus>();

            eventBus.Subscribe<AdvertVisitedIntegrationEvent, AdvertVisitedIntegrationEventHandler>();

            return serviceProvider;
        }
    }
}

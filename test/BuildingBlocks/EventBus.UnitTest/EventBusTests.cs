using EventBus.Base.Abstraction;
using EventBus.Base;
using Microsoft.Extensions.DependencyInjection;
using EventBus.Factory;
using EventBus.UnitTest.Events.Events;
using EventBus.UnitTest.Events.EventHandlers;

namespace EventBus.UnitTest
{
    [TestClass]
    public class EventBusTests
    {
        private ServiceCollection services;

        public EventBusTests()
        {
            services = new ServiceCollection();
        }

        [TestMethod]
        public void subscribe_event_on_rabbitmq_test()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);

            });

            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            eventBus.Subscribe<AdvertVisitedIntegrationEvent, AdvertVisitedIntegrationEventHandler>();
            //eventBus.UnSubscribe<AdvertVisitedIntegrationEvent, AdvertVisitedIntegrationEventHandler>();
        }

        [TestMethod]
        public void send_message_to_rabbitmq_test()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);

            });

            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();
            eventBus.Publish(new AdvertVisitedIntegrationEvent(1));
        }

        private EventBusConfig GetRabbitMQConfig()
        {
            return new EventBusConfig()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "VehicleTopicName",
                EventBusType = EventBusType.RabbitMQ,
                EventNameSuffix = "IntegrationEvent",

                //# RabbitMQ integration using default settings
                //Connection = new ConnectionFactory()
                //{
                //    HostName = "localhost",
                //    Port = 5672,
                //    UserName = "guest",
                //    Password = "guest"
                //}
            };
        }
    }
}
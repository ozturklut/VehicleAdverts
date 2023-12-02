using AdvertVisitService.API.Infrastructure.Services.Abstract;
using AdvertVisitService.API.IntegrationEvents.Events;
using EventBus.Base.Abstraction;

namespace AdvertVisitService.API.IntegrationEvents.EventHandlers
{
    public class AdvertVisitedIntegrationEventHandler : IIntegrationEventHandler<AdvertVisitedIntegrationEvent>
    {
        private readonly IAdvertVisitsService _visitsService;

        public AdvertVisitedIntegrationEventHandler(IAdvertVisitsService visitsService)
        {
            _visitsService = visitsService;
        }

        public async Task Handle(AdvertVisitedIntegrationEvent @event)
        {
			try
			{
                await _visitsService.CreateAdvertVisit(new Core.Domain.Models.Request.AdvertVisit.CreateAdvertVisitRequestModel() { 
                    AdvertId = @event.AdvertId,
                    IPAdress = @event.IpAddress,
                    VisitDate = @event.VisitDate
                    });
                    

			}
			catch (Exception ex)
			{
                // add logs
			}
        }
    }
}

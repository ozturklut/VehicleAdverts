using EventBus.Base.Events;

namespace AdvertsService.API.IntegrationEvents.Events
{
    public class AdvertVisitedIntegrationEvent : IntegrationEvent
    {
        public int AdvertId { get; set; }
        public string IpAddress { get; set; }
        public DateTime VisitDate { get; set; }
        public AdvertVisitedIntegrationEvent()
        {

        }
        public AdvertVisitedIntegrationEvent(int advertId, string ipAddress, DateTime visitDate)
        {
            AdvertId = advertId;
            IpAddress = ipAddress;
            VisitDate = visitDate;
        }
    }
}

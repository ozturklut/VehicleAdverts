namespace AdvertVisitService.API.Core.Domain.Models.Request.AdvertVisit
{
    public class CreateAdvertVisitRequestModel
    {
        public int AdvertId { get; set; }
        public string IPAdress { get; set; }
        public DateTime VisitDate { get; set; }
    }
}

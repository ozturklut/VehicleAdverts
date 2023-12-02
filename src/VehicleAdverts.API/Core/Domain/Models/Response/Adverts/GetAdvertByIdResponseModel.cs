using VehicleAdverts.API.Core.Domain.Models.Response.Adverts.Base;

namespace VehicleAdverts.API.Core.Domain.Models.Response.Adverts
{
    public class GetAdvertByIdResponseModel : BaseAdvertResponseModel
    {
        public int MemberId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int TownId { get; set; }
        public string TownName { get; set; }
        public int ModelId { get; set; }
        public int CategoryId { get; set; }
        public string SecondPhoto { get; set; }
        public string UserInfo { get; set; }
        public string Text { get; set; }
    }
}

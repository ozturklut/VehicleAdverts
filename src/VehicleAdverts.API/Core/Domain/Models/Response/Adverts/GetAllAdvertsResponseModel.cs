using VehicleAdverts.API.Core.Domain.Models.Response.Base;

namespace VehicleAdverts.API.Core.Domain.Models.Response.Adverts
{
    public class GetAllAdvertsResponseModel : PaginationResponseModel
    {
        public List<GetAllAdvertsItem> Adverts { get; set; }
    }
}


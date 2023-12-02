using VehicleAdverts.API.Core.Domain.Models.Request.Adverts;
using VehicleAdverts.API.Core.Domain.Models.Request.Base;
using VehicleAdverts.API.Core.Domain.Models.Response.Adverts;
using VehicleAdverts.API.Core.Domain.Models.Response.Base;

namespace VehicleAdverts.API.Infrastructure.Services.Abstract
{
    public interface IAdvertsService
    {
        Task<ApiBaseResponseModel<GetAllAdvertsResponseModel>> GetAllAdvert(GetAllAdvertsRequestModel requestModel);
        Task<ApiBaseResponseModel<GetAdvertByIdResponseModel>> GetAdvertById(BaseByIdRequestModel requestModel);
    }
}

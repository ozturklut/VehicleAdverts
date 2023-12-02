using AdvertVisitService.API.Core.Domain.Models.Request.AdvertVisit;
using AdvertVisitService.API.Core.Domain.Models.Request.Base;
using AdvertVisitService.API.Core.Domain.Models.Response.Base;

namespace AdvertVisitService.API.Infrastructure.Services.Abstract
{
    public interface IAdvertVisitsService
    {
        Task<ApiBaseResponseModel<bool>> CreateAdvertVisit(CreateAdvertVisitRequestModel requestModel);
        Task<ApiBaseResponseModel<int>> GetAdvertVisitCount(BaseByIdRequestModel requestModel);
    }
}

using Microsoft.AspNetCore.Mvc;
using VehicleAdverts.API.Core.Domain.Models.Request.Adverts;
using VehicleAdverts.API.Core.Domain.Models.Response.Adverts;
using VehicleAdverts.API.Core.Domain.Models.Response.Base;
using VehicleAdverts.API.Infrastructure.Services.Abstract;

namespace VehicleAdverts.API.Controllers
{
    [Route("advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertsService _advertsService;

        public AdvertController(IAdvertsService advertsService)
        {
            _advertsService = advertsService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(ApiBaseResponseModel<GetAllAdvertsResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> All([FromQuery] GetAllAdvertsRequestModel requestModel)
        {
            var responseModel = await _advertsService.GetAllAdvert(requestModel);
            return responseModel.Success ? Ok(responseModel) : BadRequest(responseModel);
        }
    }
}

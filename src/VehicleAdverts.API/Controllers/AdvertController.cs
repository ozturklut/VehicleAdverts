using Microsoft.AspNetCore.Mvc;
using VehicleAdverts.API.Core.Domain.Models.Request.Adverts;
using VehicleAdverts.API.Core.Domain.Models.Request.Base;
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAdvert([FromQuery] GetAllAdvertsRequestModel requestModel)
        {
            var responseModel = await _advertsService.GetAllAdvert(requestModel);

            if (responseModel.Success && responseModel.Data.Adverts.Count == 0)
            {
                return NoContent();
            }
            return responseModel.Success ? Ok(responseModel) : StatusCode(500, responseModel);
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(ApiBaseResponseModel<GetAdvertByIdResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdvertById([FromQuery] BaseByIdRequestModel requestModel)
        {
            var responseModel = await _advertsService.GetAdvertById(requestModel);

            if (!responseModel.Success)
            {
                return responseModel.Data == null
                    ? NoContent()
                    : StatusCode(500, responseModel);
            }

            return Ok(responseModel);
        }
    }
}

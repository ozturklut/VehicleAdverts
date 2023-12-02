using AdvertVisitService.API.Core.Domain.Models.Request.Base;
using AdvertVisitService.API.Core.Domain.Models.Response.Base;
using AdvertVisitService.API.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvertVisitService.API.Controllers
{
    [Route("advertvisit")]
    [ApiController]
    public class AdvertVisitController : ControllerBase
    {
        private readonly IAdvertVisitsService _advertVisitService;

        public AdvertVisitController(IAdvertVisitsService advertVisitService)
        {
            _advertVisitService = advertVisitService;
        }

        [HttpGet("count")]
        [ProducesResponseType(typeof(ApiBaseResponseModel<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdvertVisitCount([FromQuery] BaseByIdRequestModel requestModel)
        {
            var responseModel = await _advertVisitService.GetAdvertVisitCount(requestModel);
            return responseModel.Success ? Ok(responseModel) : StatusCode(500, responseModel);
        }
    }
}

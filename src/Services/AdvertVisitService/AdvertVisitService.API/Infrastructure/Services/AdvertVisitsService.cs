using AdvertVisitService.API.Core.Domain.Models.Request.AdvertVisit;
using AdvertVisitService.API.Core.Domain.Models.Request.Base;
using AdvertVisitService.API.Core.Domain.Models.Response.Base;
using AdvertVisitService.API.Infrastructure.Services.Abstract;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AdvertVisitService.API.Infrastructure.Services
{
    public class AdvertVisitsService : BaseService, IAdvertVisitsService
    {
        private readonly IConfiguration _configuration;

        public AdvertVisitsService(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ApiBaseResponseModel<bool>> CreateAdvertVisit(CreateAdvertVisitRequestModel requestModel)
        {
            var responseModel = new ApiBaseResponseModel<bool>();

            try
            {

                var sql = $@"INSERT INTO AdvertVisits(AdvertId,IPAdress,VisitDate) VALUES(@AdvertId,@IPAdress,@VisitDate)";

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await con.ExecuteAsync(sql, requestModel);

                    responseModel.Data = result > 0 ? true : throw new Exception();
                    responseModel.Success = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "An unexpected error occurred.";
                responseModel.DetailMessage = ex.Message;
            }

            return responseModel;
        }

        public async Task<ApiBaseResponseModel<int>> GetAdvertVisitCount(BaseByIdRequestModel requestModel)
        {
            var responseModel = new ApiBaseResponseModel<int>();

            try
            {

                var sql = $@"SELECT COUNT(0) FROM AdvertVisits WITH(NOLOCK) WHERE AdvertId = 7333920";

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await con.QueryAsync<int>(sql, requestModel);

                    responseModel.Data = result.Single();
                    responseModel.Success = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "An unexpected error occurred.";
                responseModel.DetailMessage = ex.Message;
            }

            return responseModel;
        }
    }
}

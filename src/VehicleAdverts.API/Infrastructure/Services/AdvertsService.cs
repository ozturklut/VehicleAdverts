using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VehicleAdverts.API.Core.Domain.Entities;
using VehicleAdverts.API.Core.Domain.Models.Request.Adverts;
using VehicleAdverts.API.Core.Domain.Models.Response.Adverts;
using VehicleAdverts.API.Core.Domain.Models.Response.Base;
using VehicleAdverts.API.Infrastructure.Services.Abstract;
using static System.Net.Mime.MediaTypeNames;

namespace VehicleAdverts.API.Infrastructure.Services
{
    public class AdvertsService : BaseService, IAdvertsService
    {
        private readonly IConfiguration _configuration;

        // REVIEW: Dependency Injection (Bağımlılık Enjeksiyonu) için constructor kullanımı
        public AdvertsService(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ApiBaseResponseModel<GetAllAdvertsResponseModel>> GetAllAdvert(GetAllAdvertsRequestModel requestModel)
        {
            var responseModel = new ApiBaseResponseModel<GetAllAdvertsResponseModel>();

            try
            {
                var whereFilterSql = BuildWhereFilterSql(requestModel);
                var orderBySql = BuildOrderBySql(requestModel);
                var pagingSql = BuildPagingSql(requestModel);

                var countSql = $@"SELECT COUNT(Id) FROM Adverts WITH(NOLOCK) {whereFilterSql}";
                var totalRecords = 0;
                var totalPages = 0;

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    totalRecords = await con.ExecuteScalarAsync<int>(countSql, requestModel);
                }

                if (requestModel.PageNumber != null && requestModel.PageSize != null && requestModel.PageSize > 0)
                {
                    totalPages = (int)Math.Ceiling((double)totalRecords / (double)requestModel.PageSize);
                }

                var sql = $@"SELECT
                Id,
                ModelName,
                Category,
                Year,
                Price,
                Title,
                Date,
                Km,
                Color,
                Gear,
                Fuel,
                FirstPhoto
                FROM Adverts WITH(NOLOCK) 
                {whereFilterSql}
                {orderBySql}
                {pagingSql}";

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await con.QueryAsync<GetAllAdvertsItem>(sql, requestModel);

                    responseModel.Data.PageNumber = requestModel.PageNumber;
                    responseModel.Data.PageSize = requestModel.PageSize;
                    responseModel.Data.TotalPages = totalPages;
                    responseModel.Data.TotalRecords = totalRecords;
                    responseModel.Data.Adverts = result.ToList();
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

        private string BuildWhereFilterSql(GetAllAdvertsRequestModel requestModel)
        {
            var conditions = new List<string>();

            if (requestModel.CategoryId != null) conditions.Add("CategoryId = @CategoryId");
            if (requestModel.Fuel != null) conditions.Add("Fuel = @Fuel");
            if (requestModel.Gear != null) conditions.Add("Gear = @Gear");
            if (requestModel.MinPrice != null) conditions.Add("Price >= @MinPrice");
            if (requestModel.MaxPrice != null) conditions.Add("Price <= @MaxPrice");

            return conditions.Any() ? "WHERE " + string.Join(" AND ", conditions) : "";
        }

        private string BuildOrderBySql(GetAllAdvertsRequestModel requestModel)
        {
            if (!string.IsNullOrWhiteSpace(requestModel.SortField))
            {
                var sortOrder = requestModel.SortOrder.ToLower() == "desc" ? "DESC" : "ASC";
                switch (requestModel.SortField.ToLower())
                {
                    case "price":
                        return $" ORDER BY Price {sortOrder}";
                    case "year":
                        return $" ORDER BY Year {sortOrder}";
                    case "km":
                        return $" ORDER BY Km {sortOrder}";
                }
            }
            return " ORDER BY Id";
        }

        private string BuildPagingSql(GetAllAdvertsRequestModel requestModel)
        {
            if (requestModel.PageSize != null && requestModel.PageNumber != null && requestModel.PageSize > 0)
            {
                return $" OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY";
            }
            return "";
        }
    }
}

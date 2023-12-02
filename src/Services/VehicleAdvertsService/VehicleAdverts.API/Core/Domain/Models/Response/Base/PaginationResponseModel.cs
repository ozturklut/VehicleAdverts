namespace VehicleAdverts.API.Core.Domain.Models.Response.Base
{
    public class PaginationResponseModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
    }
}

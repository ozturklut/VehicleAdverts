using System.ComponentModel.DataAnnotations;

namespace VehicleAdverts.API.Core.Domain.Models.Request.Base
{
    public class PaginationRequestModel
    {
        [Range(1, double.MaxValue, ErrorMessage = "PageNumber must be greater than 0")]
        public int? PageNumber { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "PageSize must be greater than 0")]
        public int? PageSize { get; set; }
    }
}

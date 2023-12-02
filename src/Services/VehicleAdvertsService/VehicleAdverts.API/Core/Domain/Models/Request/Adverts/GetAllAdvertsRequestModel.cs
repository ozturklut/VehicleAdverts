using System.ComponentModel.DataAnnotations;
using VehicleAdverts.API.Core.Domain.Models.Request.Base;

namespace VehicleAdverts.API.Core.Domain.Models.Request.Adverts
{
    public class GetAllAdvertsRequestModel : PaginationRequestModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
        public int? CategoryId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        public double? MinPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        public double? MaxPrice { get; set; }
        public string? Gear { get; set; }
        public string? Fuel { get; set; }
        public string? SortField { get; set; } 
        public string SortOrder { get; set; } = "";
    }
}

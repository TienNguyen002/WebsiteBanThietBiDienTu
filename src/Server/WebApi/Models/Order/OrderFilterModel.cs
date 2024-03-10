using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApi.Models.Order
{
    public class OrderFilterModel : PagingModel
    {
        public string Keyword { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? StatusId { get; set; }

        public IEnumerable<SelectListItem> StatusList { get; set; }
    }
}

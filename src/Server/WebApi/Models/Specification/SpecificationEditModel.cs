using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Models.Specification
{
    public class SpecificationEditModel
    {
        public int Id { get; set; }

        [DisplayName("Chi tiết thông số")]
        [Required(ErrorMessage = "Chi tiết thông số không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Chi tiết thông số tối đa 100 ký tự")]
        public string Details { get; set; }

        [DisplayName("Danh mục thông số")]
        [Required(ErrorMessage = "Danh mục thông số không được bỏ trống")]
        public int SpeCategoryId { get; set; }

        public static async ValueTask<SpecificationEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new SpecificationEditModel()
            {
                Id = int.Parse(form["Id"]),
                Details = form["Details"],
                SpeCategoryId = int.Parse(form["SpeCategoryId"]),
            };
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Models.SpecificationCategory
{
    public class SpecificationCategoryEditModel
    {
        public int Id { get; set; }

        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Tên danh mục tối đa 100 ký tự")]
        public string Name { get; set; }

        [DisplayName("Slug danh mục")]
        [Required(ErrorMessage = "Slug danh mục không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Slug danh mục tối đa 100 ký tự")]
        public string UrlSlug { get; set; }

        public static async ValueTask<SpecificationCategoryEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new SpecificationCategoryEditModel()
            {
                Id = int.Parse(form["Id"]),
                Name = form["Name"],
                UrlSlug = form["UrlSlug"]
            };
        }
    }
}

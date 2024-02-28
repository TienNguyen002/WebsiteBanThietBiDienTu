using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Category
{
    public class CategoryEditModel
    {
        public int Id { get; set; }

        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được bỏ trống")]
        [MaxLength(500, ErrorMessage = "Tên danh mục tối đa 500 ký tự")]
        public string Name { get; set; }

        public static async ValueTask<CategoryEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new CategoryEditModel()
            {
                Id = int.Parse(form["Id"]),
                Name = form["Name"],
            };
        }
    }
}

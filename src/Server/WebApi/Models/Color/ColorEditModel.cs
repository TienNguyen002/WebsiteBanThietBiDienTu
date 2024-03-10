using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Models.Color
{
    public class ColorEditModel
    {
        public int Id { get; set; }

        [DisplayName("Tên màu")]
        [Required(ErrorMessage = "Tên màu không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Tên màu tối đa 100 ký tự")]
        public string Name { get; set; }

        [DisplayName("Slug màu")]
        [Required(ErrorMessage = "Slug màu không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Slug màu tối đa 100 ký tự")]
        public string UrlSlug { get; set; }

        public static async ValueTask<ColorEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new ColorEditModel()
            {
                Id = int.Parse(form["Id"]),
                Name = form["Name"],
                UrlSlug = form["UrlSlug"]
            };
        }
    }
}

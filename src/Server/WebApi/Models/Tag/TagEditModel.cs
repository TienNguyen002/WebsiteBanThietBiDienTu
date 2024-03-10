using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApi.Models.SpecificationCategory;

namespace WebApi.Models.Tag
{
    public class TagEditModel
    {
        public int Id { get; set; }

        [DisplayName("Tên tag")]
        [Required(ErrorMessage = "Tên tag không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Tên tag tối đa 100 ký tự")]
        public string Name { get; set; }

        [DisplayName("Slug tag")]
        [Required(ErrorMessage = "Slug tag không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Slug tag tối đa 100 ký tự")]
        public string UrlSlug { get; set; }

        public static async ValueTask<TagEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new TagEditModel()
            {
                Id = int.Parse(form["Id"]),
                Name = form["Name"],
                UrlSlug = form["UrlSlug"]
            };
        }
    }
}

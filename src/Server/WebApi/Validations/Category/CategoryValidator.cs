using FluentValidation;
using WebApi.Models.Category;

namespace WebApi.Validations.Category
{
    public class CategoryValidator : AbstractValidator<CategoryEditModel>
    {
        public CategoryValidator()
        {
            RuleFor(l => l.Name)
                .NotEmpty()
                .WithMessage("Tên danh mục không được để trống")
                .MaximumLength(500)
                .WithMessage("Tên danh mục chỉ tối đa 500 ký tự");
        }
    }
}

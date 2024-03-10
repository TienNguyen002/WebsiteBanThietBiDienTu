using FluentValidation;
using WebApi.Models.SpecificationCategory;

namespace WebApi.Validations.SpecificationCategory
{
    public class SpecificationCategoryValidator : AbstractValidator<SpecificationCategoryEditModel>
    {
        public SpecificationCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Tên danh mục không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Danh mục chỉ tối đa 100 ký tự");

            RuleFor(c => c.UrlSlug)
                .NotEmpty()
                .WithMessage("Tên danh mục không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Danh mục chỉ tối đa 100 ký tự");
        }
    }
}

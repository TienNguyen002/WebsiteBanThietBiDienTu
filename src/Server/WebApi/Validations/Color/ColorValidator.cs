using FluentValidation;
using WebApi.Models.Color;

namespace WebApi.Validations.Color
{
    public class ColorValidator : AbstractValidator<ColorEditModel>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Tên màu không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Màu chỉ tối đa 100 ký tự");

            RuleFor(c => c.UrlSlug)
                .NotEmpty()
                .WithMessage("Tên màu không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Màu chỉ tối đa 100 ký tự");
        }
    }
}

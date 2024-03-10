using FluentValidation;
using WebApi.Models.Trademark;

namespace WebApi.Validations.Trademark
{
    public class TrademarkValidator : AbstractValidator<TrademarkEditModel>
    {
        public TrademarkValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Tên thương hiệu không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Thương hiệu chỉ tối đa 100 ký tự");

            RuleFor(c => c.UrlSlug)
                .NotEmpty()
                .WithMessage("Tên thương hiệu không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Thương hiệu chỉ tối đa 100 ký tự");
        }
    }
}

using FluentValidation;
using WebApi.Models.Tag;

namespace WebApi.Validations.Tag
{
    public class TagValidator : AbstractValidator<TagEditModel>
    {
        public TagValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Tên tag không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Tag chỉ tối đa 100 ký tự");

            RuleFor(c => c.UrlSlug)
                .NotEmpty()
                .WithMessage("Tên tag không được bỏ trống")
                .MaximumLength(100)
                .WithMessage("Tag chỉ tối đa 100 ký tự");
        }
    }
}

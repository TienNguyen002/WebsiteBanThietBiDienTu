using FluentValidation;
using WebApi.Models.Specification;

namespace WebApi.Validations.Specification
{
    public class SpecificationValidator : AbstractValidator<SpecificationEditModel>
    {
        public SpecificationValidator()
        {
            RuleFor(s => s.Details)
                .NotEmpty()
                .WithMessage("Chi tiết thông số không được để trống")
                .MaximumLength(500)
                .WithMessage("Chi tiết thông số chỉ tối đa 500 ký tự");
        }
    }
}

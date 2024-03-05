using FluentValidation;
using WebApi.Models.Comment;

namespace WebApi.Validations.Comment
{
    public class CommentValidator : AbstractValidator<CommentEditModel>
    {
        public CommentValidator()
        {
            RuleFor(l => l.Detail)
                .NotEmpty()
                .WithMessage("Nội dung không được để trống")
                .MaximumLength(500)
                .WithMessage("Nội dung chỉ tối đa 500 ký tự");
        }
    }
}

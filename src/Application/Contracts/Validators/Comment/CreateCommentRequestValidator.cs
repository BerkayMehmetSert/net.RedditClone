using Application.Contracts.Constants.Comment;
using Application.Contracts.Requests.Comment;
using FluentValidation;

namespace Application.Contracts.Validators.Comment;

public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentRequestValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .NotNull()
            .WithMessage(CommentValidationMessages.TextRequired)
            .Length(3, 500)
            .WithMessage(CommentValidationMessages.TextLength);
    }
}
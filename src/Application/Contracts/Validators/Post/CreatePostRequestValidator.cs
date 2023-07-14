using Application.Contracts.Constants.Post;
using Application.Contracts.Requests.Post;
using FluentValidation;

namespace Application.Contracts.Validators.Post;

public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
{
    public CreatePostRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(PostValidationMessages.NameRequired)
            .Length(3, 50)
            .WithMessage(PostValidationMessages.NameLength);
        
        RuleFor(x=>x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage(PostValidationMessages.DescriptionRequired)
            .Length(3, 500)
            .WithMessage(PostValidationMessages.DescriptionLength);
        
        RuleFor(x=>x.Url)
            .NotEmpty()
            .NotNull()
            .WithMessage(PostValidationMessages.UrlRequired)
            .Length(3, 120)
            .WithMessage(PostValidationMessages.UrlLength);
        
        RuleFor(x=>x.SubredditId)
            .NotEmpty()
            .NotNull()
            .WithMessage(PostValidationMessages.SubredditIdRequired);
    }
}
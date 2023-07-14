using Application.Contracts.Constants.Subreddit;
using Application.Contracts.Requests.Subreddit;
using FluentValidation;

namespace Application.Contracts.Validators.Subreddit;

public class CreateSubredditRequestValidator : AbstractValidator<CreateSubredditRequest>
{
    public CreateSubredditRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(SubredditValidationMessages.NameRequired)
            .Length(3, 50)
            .WithMessage(SubredditValidationMessages.NameLength);
        
        RuleFor(x=>x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage(SubredditValidationMessages.DescriptionRequired)
            .Length(3, 500)
            .WithMessage(SubredditValidationMessages.DescriptionLength);
    }
}
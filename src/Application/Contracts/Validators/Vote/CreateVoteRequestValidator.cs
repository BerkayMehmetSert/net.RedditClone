using Application.Contracts.Constants.Vote;
using Application.Contracts.Requests.Vote;
using FluentValidation;

namespace Application.Contracts.Validators.Vote;

public class CreateVoteRequestValidator : AbstractValidator<CreateVoteRequest>
{
    public CreateVoteRequestValidator()
    {
        RuleFor(x => x.PostId)
            .NotNull()
            .NotEmpty()
            .WithMessage(VoteValidationMessages.PostIdRequired);
        
        RuleFor(x=>x.VoteType)
            .NotNull()
            .NotEmpty()
            .WithMessage(VoteValidationMessages.VoteTypeRequired);
    }
}
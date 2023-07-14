using Application.Contracts.Constants.User;
using Application.Contracts.Requests.User;
using FluentValidation;

namespace Application.Contracts.Validators.User;

public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(x=>x.Username)
            .NotNull()
            .NotEmpty()
            .WithMessage(UserValidationMessages.UsernameRequired)
            .Length(3, 50)
            .WithMessage(UserValidationMessages.UsernameLength);
        
        RuleFor(x=>x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage(UserValidationMessages.EmailRequired)
            .EmailAddress()
            .WithMessage(UserValidationMessages.EmailInvalid);
        
        RuleFor(x=>x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage(UserValidationMessages.PasswordRequired);
    }
}
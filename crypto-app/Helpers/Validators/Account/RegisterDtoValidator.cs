using crypto_app.Helpers.DTOs.Account;
using FluentValidation;

namespace crypto_app.Helpers.Validators.Account;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(30)
            .MinimumLength(3)
            .WithMessage("Name duzgun daxil edin");

        RuleFor(x => x.Email)
           .NotEmpty()
           .NotNull()
           .EmailAddress()
           .WithMessage("Email duzgun daxil edin");

        RuleFor(x => x.Password)
          .NotEmpty()
          .NotNull()
          .Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
          .WithMessage("Password tipini duzgun daxil edin");


        RuleFor(x => x.Password)
          .NotEmpty()
          .NotNull()
          .Equal(x => x.Password)
          .WithMessage("Passwords don't match");
    }
}

using crypto_app.Helpers.DTOs.Account;
using FluentValidation;

namespace crypto_app.Helpers.Validators.Account;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.EmailOrUsername)
            .NotEmpty()
            .NotNull()
            .MaximumLength(30)
            .MinimumLength(3)
            .WithMessage("Email or Username yanlisdir");

        RuleFor(x => x.Password)
          .NotEmpty()
          .NotNull()
          .Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
          .WithMessage("Password tipini duzgun daxil edin");
    }
}

using crypto_app.Helpers.DTOs.Positions;
using crypto_app.Models;
using FluentValidation;

namespace crypto_app.Helpers.Validators.Positions;

public class UpdatePositionDtoValidator : AbstractValidator<UpdatePositionDto>
{
    public UpdatePositionDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(30)
            .MinimumLength(3)
            .WithMessage("Name duzgun daxil edin");
    }
}

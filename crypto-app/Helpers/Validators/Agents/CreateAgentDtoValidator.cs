using crypto_app.Helpers.DTOs.Agents;
using FluentValidation;

namespace crypto_app.Helpers.Validators.Agents;

public class CreateAgentDtoValidator : AbstractValidator<CreateAgentDto>
{
    public CreateAgentDtoValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .NotNull()
           .MaximumLength(30)
           .MinimumLength(3)
           .WithMessage("Name duzgun daxil edin");

        RuleFor(x => x.PositionId)
          .NotEmpty()
          .NotNull()
          .WithMessage("Position Duzgun daxil edin");
    }
}

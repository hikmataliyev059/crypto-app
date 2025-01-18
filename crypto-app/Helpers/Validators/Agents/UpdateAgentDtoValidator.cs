using crypto_app.Helpers.DTOs.Agents;
using FluentValidation;

namespace crypto_app.Helpers.Validators.Agents;

public class UpdateAgentDtoValidator : AbstractValidator<UpdateAgentDto>
{
    public UpdateAgentDtoValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .NotNull()
           .MaximumLength(30)
           .MinimumLength(3)
           .WithMessage("Name duzgun daxil edin");
    }
}

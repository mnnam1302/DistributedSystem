using FluentValidation;

namespace DistributedSystem.Contract.Services.V1.Identity.Validators;

public class CreateAppUserRoleValidator : AbstractValidator<Command.CreateAppUserRoleCommand>
{
    public CreateAppUserRoleValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");

        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("RoleId is required");
    }
}

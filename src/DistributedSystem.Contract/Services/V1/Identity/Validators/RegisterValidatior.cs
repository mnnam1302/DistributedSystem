using FluentValidation;

namespace DistributedSystem.Contract.Services.V1.Identity.Validators;

public class RegisterValidatior : AbstractValidator<Command.RegisterUserCommand>
{
    public RegisterValidatior()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();

        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.PasswordConfirm).Equal(x => x.Password)
            .WithMessage("The password and confirm password is not match");
    }
}

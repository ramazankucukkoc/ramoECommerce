using Application.Features.Users.Commands;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Users.Validator
{
    public class UserValidator:AbstractValidator<ChangePasswordCommand>
    {
        public UserValidator()
        {
            RuleFor(p => p.CurrentPassword).NotEmpty().WithMessage("Password required");
            RuleFor(p => p.NewPassword).Password();
            RuleFor(p => p.CurrentPassword).Equal(u => u.NewPassword).WithMessage("The password doesn't match.");
        }

    }
}

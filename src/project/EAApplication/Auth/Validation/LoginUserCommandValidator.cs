using EAApplication.Auth.Commands;
using FluentValidation;

namespace EAApplication.Users.Validation
{
    public class LoginUserCommandValidator:AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            //RuleFor(p => p.LoginUserDto.Email).MinimumLength(50);
        }
    }
}

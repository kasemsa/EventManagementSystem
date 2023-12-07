using EventManagementSystem.Application.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator:AbstractValidator<LoginUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(u=>u.Email)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .NotNull();

        }
    }
}

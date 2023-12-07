using EventManagementSystem.Application.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(u => u.Email)
               .NotNull()
               .NotEmpty().WithMessage("{ProoertyName} is Required")
               .EmailAddress();

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .NotNull()
                .MinimumLength(8);

            RuleFor(u => u.Name)
               .NotEmpty().WithMessage("{ProoertyName} is Required")
               .NotNull();

            RuleFor(u => u.Roll)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .NotNull();
        }
    }
}

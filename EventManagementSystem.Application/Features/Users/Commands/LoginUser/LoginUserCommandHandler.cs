using AutoMapper;
using EventManagementSystem.Application.Repositories;
using EventManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler:IRequestHandler<LoginUserCommand,Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var validator = new LoginUserCommandValidator(_userRepository);

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count>0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            await _userRepository.LoginUser(request.Email,request.Password);

            return Unit.Value;
        }
    }
}

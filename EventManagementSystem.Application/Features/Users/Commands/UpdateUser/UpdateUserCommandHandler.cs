using AutoMapper;
using EventManagementSystem.Application.Repositories;
using EventManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetById(request.Id);
            if (userToUpdate == null)
            {
                throw new Exceptions.NotFoundException("User Not Found",userToUpdate);
            }
            var validator = new UpdateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count>0)
            {

                throw new Exceptions.ValidationException(validationResult);
            }

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));

            return Unit.Value;
        }
    }
}

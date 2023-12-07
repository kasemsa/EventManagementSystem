using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler:IRequestHandler<DeleteUserCommand,Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        { 
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete =await _userRepository.GetById(request.UserId);
            if (userToDelete == null)
            {
                throw new DllNotFoundException();
            }

            await _userRepository.DeleteAsync(userToDelete);

            return Unit.Value;
        }
    }
}

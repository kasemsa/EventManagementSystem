using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQuery, UserByIdVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserByIdVm> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);

            if (user == null)
            {
                throw new Exceptions.NotFoundException("User Not Found" , request.UserId);
            }

            return _mapper.Map<UserByIdVm>(user);
        }
    }
}

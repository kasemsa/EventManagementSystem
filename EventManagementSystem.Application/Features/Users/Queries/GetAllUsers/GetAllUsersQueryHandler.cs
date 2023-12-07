using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler:IRequestHandler<GetAllUsersQuery,List<UserListVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _userRepository.GetAllAsync()).OrderBy(u => u.DateCreated);
            return _mapper.Map<List<UserListVm>>(allUsers);
        }
    }
}

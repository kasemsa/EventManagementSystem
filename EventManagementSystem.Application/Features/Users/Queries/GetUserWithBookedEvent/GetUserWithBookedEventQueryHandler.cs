using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetUserWithBookedEvent
{
    public class GetUserWithBookedEventQueryHandler:IRequestHandler<GetUserWithBookedEventQuery,UserWithBookedVm>
    {
        private readonly IUserRepository  _userRepository;
        private readonly IMapper _mapper;

        public GetUserWithBookedEventQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserWithBookedVm> Handle(GetUserWithBookedEventQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.UserId);
            if (user == null)
            {
                throw new Exceptions.NotFoundException("User Not Found", request);
            }

            var UserWhithEvents = await _userRepository.GetUserWithBookedEvent(request.UserId);
                

            return _mapper.Map<UserWithBookedVm>(UserWhithEvents);

        }
    }
}

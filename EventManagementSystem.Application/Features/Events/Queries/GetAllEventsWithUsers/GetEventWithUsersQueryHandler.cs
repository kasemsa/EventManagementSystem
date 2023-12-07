using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetAllEventsWithUsers
{
    public class GetEventWithUsersQueryHandler:IRequestHandler<GetEventWithUsersQuery,EventWithUsersVm>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventWithUsersQueryHandler(IEventRepository evRepository, IMapper mapper)
        {
            _eventRepository = evRepository;
            _mapper = mapper;
        }

        public async Task<EventWithUsersVm> Handle(GetEventWithUsersQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _eventRepository.GetEventWithUsers(request.EventId);

            return _mapper.Map<EventWithUsersVm>(allEvents);
        }
    }
}

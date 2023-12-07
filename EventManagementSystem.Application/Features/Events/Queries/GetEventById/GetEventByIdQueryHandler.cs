using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetEventById
{
    public class GetEventByIdQueryHandler:IRequestHandler<GetEventByIdQuery,EventVm>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
        { 
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventVm> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetById(request.EventId);
            if (@event == null)
            {
                throw new ArgumentException();
            }
            return _mapper.Map<EventVm>(@event);
        }
    }
}

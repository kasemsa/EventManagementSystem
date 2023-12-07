using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetAllEvents
{
    public class GetEventListQueryHandler:IRequestHandler<GetEventListQuery,List<EventListVm>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        
        }

        public async Task<List<EventListVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
           
            var allEvent = (await _eventRepository.GetAllAsync()).OrderBy(e=>e.DateCreated);

            return _mapper.Map<List<EventListVm>>(allEvent);
        }
    }
}

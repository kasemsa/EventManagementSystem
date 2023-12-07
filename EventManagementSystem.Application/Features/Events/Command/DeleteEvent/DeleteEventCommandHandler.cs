using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Command.DeleteEvent
{
    public class DeleteEventCommandHandler:IRequestHandler<DeleteEventCommand,Unit>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        { 
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetById(request.EventId);
            if (@event == null)
            {
                throw new Exceptions.NotFoundException("Event that has",request);
            }
            await _eventRepository.DeleteAsync(@event);

            return Unit.Value;
        }
    }
}

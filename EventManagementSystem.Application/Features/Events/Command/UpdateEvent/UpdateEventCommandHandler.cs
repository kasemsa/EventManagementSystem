using AutoMapper;
using EventManagementSystem.Application.Repositories;
using EventManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Command.UpdateEvent
{
    public class UpdateEventCommandHandler:IRequestHandler<UpdateEventCommand,Unit>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepository.GetById(request.EventId);

            if (eventToUpdate == null)
            {
                throw new Exceptions.NotFoundException("Event that has", request);
            }
            var validator = new UpdateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            return Unit.Value;
        }
    }
}

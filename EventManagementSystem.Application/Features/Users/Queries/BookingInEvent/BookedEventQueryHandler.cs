using AutoMapper;
using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.BookingInEvent
{
    public class BookedEventQueryHandler:IRequestHandler<BookedEventQuery,Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public BookedEventQueryHandler(IUserRepository userRepository,IEventRepository eventRepository ,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(BookedEventQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetById(request.EventId);

            var user = await _userRepository.GetById(request.UserId);

            if (@event == null || user ==null)
            {
                throw new Exceptions.NotFoundException("Event Not Found", request.EventId);

            }

            if (@event.NumberOfTicket <= 0 )
            {
                throw new Exceptions.NotFoundException("There No Places", request.EventId);
            }

            await _userRepository.BookedTickt(request.EventId,request.UserId);

            

            return Unit.Value;

        }
    }
}

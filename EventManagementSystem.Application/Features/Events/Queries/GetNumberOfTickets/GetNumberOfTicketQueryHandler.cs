using EventManagementSystem.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetNumberOfTickets
{
    public class GetNumberOfTicketQueryHandler:IRequestHandler<GetNumberOfTicketQuery,int>
    {
        private readonly IEventRepository _eventRepository;

        public GetNumberOfTicketQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> Handle(GetNumberOfTicketQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetById(request.EventId);
            if (@event == null)
            {
                throw new ArgumentException();
            }
            return @event.NumberOfTicket;
            
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetNumberOfTickets
{
    public class GetNumberOfTicketQuery:IRequest<int>
    {
        public int EventId { get; set; }
    }
}

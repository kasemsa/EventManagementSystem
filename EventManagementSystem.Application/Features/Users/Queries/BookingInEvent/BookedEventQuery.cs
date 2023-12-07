using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.BookingInEvent
{
    public class BookedEventQuery:IRequest<Unit>
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}

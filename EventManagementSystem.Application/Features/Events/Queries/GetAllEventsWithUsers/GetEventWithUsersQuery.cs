using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetAllEventsWithUsers
{
    public class GetEventWithUsersQuery:IRequest<EventWithUsersVm>
    {
        public int EventId { get; set; }
    }
}

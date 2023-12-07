using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetEventById
{
    public class GetEventByIdQuery:IRequest<EventVm>
    {
        public int EventId { get; set; }
    }
}

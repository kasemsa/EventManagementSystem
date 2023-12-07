using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Command.DeleteEvent
{
    public class DeleteEventCommand:IRequest<Unit>
    {
        public int EventId { get; set; }
    }
}

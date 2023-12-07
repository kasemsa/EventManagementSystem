using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetAllEventsWithUsers
{
    public class EventWithUsersVm
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;

        public string EventLocation { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }

        public int NumberOfTicket { get; set; }

        public ICollection<EventUserDto> users { get; set; } = default!;
    }
}

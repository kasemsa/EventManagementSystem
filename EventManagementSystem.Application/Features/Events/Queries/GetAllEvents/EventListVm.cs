using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Queries.GetAllEvents
{
    public class EventListVm
    {
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        public int NumberOfTicket { get; set; }
    }
}

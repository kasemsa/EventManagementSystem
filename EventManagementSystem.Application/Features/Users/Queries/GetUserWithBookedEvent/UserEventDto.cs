using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetUserWithBookedEvent
{
    public class UserEventDto
    {
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        public string EventLocation { get; set; } = string.Empty;
    }
}

using EventManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Domain.Entities
{
    public class Event:BaseEntity
    {
 
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; }=string.Empty;

        public string EventLocation { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }

        public int NumberOfTicket { get; set; }

        public ICollection<User> users { get; set; } = new List<User>();

    }
}

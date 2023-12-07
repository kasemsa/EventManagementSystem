using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetUserWithBookedEvent
{
    public class UserWithBookedVm
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<UserEventDto> events { get; set; } = default!;
    }
}

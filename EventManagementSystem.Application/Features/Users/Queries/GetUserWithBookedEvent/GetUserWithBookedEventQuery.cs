using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetUserWithBookedEvent
{
    public class GetUserWithBookedEventQuery:IRequest<UserWithBookedVm>
    {
        public int UserId { get; set; } 
    }
}

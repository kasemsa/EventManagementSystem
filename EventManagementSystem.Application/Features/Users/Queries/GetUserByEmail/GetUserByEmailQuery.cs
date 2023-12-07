using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery:IRequest<UserByEmailVm>
    {
        public string? Email { get; set; }
    }
}

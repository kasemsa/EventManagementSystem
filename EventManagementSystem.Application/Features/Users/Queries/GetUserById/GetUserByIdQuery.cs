using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery:IRequest<UserByIdVm>
    {
        public int UserId { get; set; }
    }
}

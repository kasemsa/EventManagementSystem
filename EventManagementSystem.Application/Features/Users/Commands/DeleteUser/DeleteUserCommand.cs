﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand:IRequest<Unit>
    {
        public int UserId { get; set; }
    }
}

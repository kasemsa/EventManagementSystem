using AutoMapper;
using EventManagementSystem.Application.Features.Events.Command.CreateEvent;
using EventManagementSystem.Application.Features.Events.Command.UpdateEvent;
using EventManagementSystem.Application.Features.Events.Queries.GetAllEvents;
using EventManagementSystem.Application.Features.Events.Queries.GetAllEventsWithUsers;
using EventManagementSystem.Application.Features.Events.Queries.GetEventById;
using EventManagementSystem.Application.Features.Users.Commands.CreateUser;
using EventManagementSystem.Application.Features.Users.Commands.LoginUser;
using EventManagementSystem.Application.Features.Users.Commands.UpdateUser;
using EventManagementSystem.Application.Features.Users.Queries.GetAllUsers;
using EventManagementSystem.Application.Features.Users.Queries.GetUserByEmail;
using EventManagementSystem.Application.Features.Users.Queries.GetUserById;
using EventManagementSystem.Application.Features.Users.Queries.GetUserWithBookedEvent;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Event,CreateEventCommand>().ReverseMap();
            CreateMap<Event,UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventListVm>();
            CreateMap<Event, EventWithUsersVm>();
            CreateMap<Event, EventVm>().ReverseMap();
            CreateMap<Event, UserEventDto>().ReverseMap();

            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, LoginUserCommand>().ReverseMap();
            CreateMap<User, UserListVm>().ReverseMap();
            CreateMap<User, UserByIdVm>().ReverseMap();
            CreateMap<User, UserWithBookedVm>().ReverseMap();
            CreateMap<User, UserByEmailVm>().ReverseMap();
            CreateMap<User, EventUserDto>().ReverseMap();

        }
    }
}

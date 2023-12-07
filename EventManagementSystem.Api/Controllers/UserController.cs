using AutoMapper;
using EventManagementSystem.Application.Features.Users.Commands.CreateUser;
using EventManagementSystem.Application.Features.Users.Commands.DeleteUser;
using EventManagementSystem.Application.Features.Users.Commands.LoginUser;
using EventManagementSystem.Application.Features.Users.Commands.UpdateUser;
using EventManagementSystem.Application.Features.Users.Queries.BookingInEvent;
using EventManagementSystem.Application.Features.Users.Queries.GetAllUsers;
using EventManagementSystem.Application.Features.Users.Queries.GetUserByEmail;
using EventManagementSystem.Application.Features.Users.Queries.GetUserById;
using EventManagementSystem.Application.Features.Users.Queries.GetUserWithBookedEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            var response = await _mediator.Send(updateUserCommand);
            return Ok(response);
        }

        [HttpPost("DeleteUser")]
        public async Task<ActionResult> DeleteUser([FromBody] DeleteUserCommand deleteUserCommand)
        {
            var response = await _mediator.Send(deleteUserCommand);
            return Ok(response);
        }

        [HttpGet("GetById/{Id}", Name = "GetUserById")]
        public async Task<ActionResult<UserByIdVm>> GetUserById(int id)
        {
            var User = new GetUserByIdQuery() { UserId = id };
            var response = await _mediator.Send(User);
            return Ok(response);
        }

        [HttpGet("GetByEmail/{email}", Name = "GetUserByEmail")]
        public async Task<ActionResult<UserByEmailVm>> GetUserByEmail(string Email)
        {
            var userVm = new GetUserByEmailQuery() { Email = Email };
            var response = await _mediator.Send(userVm);
            return Ok(response);
        }

        [HttpGet("GetAllUser",Name = "GetAllUsers")]
        public async Task<ActionResult<UserListVm>> GetAllUser()
        {
            var dtos = await _mediator.Send(new GetAllUsersQuery());
            return Ok(dtos);
        }

        [HttpGet("BookingEvent/{userId}/{eventId}", Name = "BookInEvent")]
        public async Task<ActionResult<Unit>> BookEvent(int userId, int eventId)
        {
            var bookingEvent = new BookedEventQuery() { EventId = eventId, UserId = userId };

            var response = await _mediator.Send(bookingEvent);

            return Ok(response);
        }

        [HttpGet("UserBookedEvents/{userId}")]
        public async Task<ActionResult<UserWithBookedVm>> UserBookedEvents(int userId)
        {
            var user =  new GetUserWithBookedEventQuery() { UserId = userId };
            var response= await _mediator.Send(user);
            return Ok(response);
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserCommand loginUserCommand)
        {
            var response = await _mediator.Send(loginUserCommand);
            return Ok(response);
        }
    }
}

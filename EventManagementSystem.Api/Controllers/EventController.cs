using EventManagementSystem.Application.Features.Events.Command.CreateEvent;
using EventManagementSystem.Application.Features.Events.Command.DeleteEvent;
using EventManagementSystem.Application.Features.Events.Command.UpdateEvent;
using EventManagementSystem.Application.Features.Events.Queries.GetAllEvents;
using EventManagementSystem.Application.Features.Events.Queries.GetAllEventsWithUsers;
using EventManagementSystem.Application.Features.Events.Queries.GetEventById;
using EventManagementSystem.Application.Features.Users.Commands.CreateUser;
using EventManagementSystem.Application.Features.Users.Commands.DeleteUser;
using EventManagementSystem.Application.Features.Users.Commands.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateEvent")]
        public async Task<ActionResult> CreateEvent([FromBody] CreateEventCommand createEventCommand)
        {
            var response = await _mediator.Send(createEventCommand);
            return Ok(response);
        }

        [HttpPost("UpdateEvent")]
        public async Task<ActionResult> UpdateEvent([FromBody] UpdateEventCommand updateEventCommand)
        {
            var response = await _mediator.Send(updateEventCommand);
            return Ok(response);
        }

        [HttpPost("DeleteEvent")]
        public async Task<ActionResult> DeleteEvent([FromBody] DeleteEventCommand deleteEventCommand)
        {
            var response = await _mediator.Send(deleteEventCommand);
            return Ok(response);
        }


        [HttpGet("getById{id}", Name = "GetEventById")]

        public async Task<ActionResult<EventVm>> GetEventById(int id)
        {
            var @event = new GetEventByIdQuery() { EventId = id };

            var response = await _mediator.Send(@event);
            return Ok(response);
        }

        [HttpGet("getAllEvent",Name = "GetAllEvents")]
        public async Task<ActionResult<EventListVm>> GetAllEvent()
        {
            var @allEvents = new GetEventListQuery();

            var response = await _mediator.Send(@allEvents);

            return Ok(response);

        }

        [HttpGet("withUsers/{id}", Name = "GetEventWithUsers")]

        public async Task<ActionResult<EventWithUsersVm>> GetEventWithUsers(int id)
        {
            var @allEvents = new GetEventWithUsersQuery() {EventId= id };

            var response = await _mediator.Send(@allEvents);

            return Ok(response);

        }
    }
}

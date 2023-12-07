using EventManagementSystem.Application.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(e => e.EventName)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("{ProoertyName} must not exceed 50 characters");

            RuleFor(e => e.EventDescription)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .NotNull()
                .MaximumLength(150).WithMessage("{ProoertyName} must not exceed 150 characters");

            RuleFor(e => e.NumberOfTicket)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .GreaterThan(0);



        }
    }
}

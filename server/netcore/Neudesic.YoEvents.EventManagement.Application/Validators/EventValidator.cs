using FluentValidation;
using Neudesic.YoEvents.EventManagement.Application.Models;

namespace Neudesic.YoEvents.EventManagement.Application.Validators
{
    public class EventValidator : AbstractValidator<EventViewModel>
    {
        public EventValidator()
        {
            RuleFor(e => e.EventTitle).NotEmpty().WithMessage("Please specify the title for the event.").MinimumLength(5).WithMessage("Title must be atleast 5 chars long.");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Please specify the description for the event.");
        }
    }
}

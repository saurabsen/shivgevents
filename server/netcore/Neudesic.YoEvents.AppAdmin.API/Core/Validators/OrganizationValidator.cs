using FluentValidation;
using Neudesic.YoEvents.AppAdmin.Core.Entities;

namespace Neudesic.YoEvents.EventManagement.Application.Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Organization name can't be blank.").MinimumLength(3).WithMessage("Name must be atleast 3 chars long.");
        }
    }
}

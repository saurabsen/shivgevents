using Neudesic.YoEvents.EventManagement.Domain.Common;
using System;

namespace Neudesic.YoEvents.EventManagement.Domain.Entities
{
    public class EventType : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private EventType()
        { }

        public EventType(Guid organizationId, string name, string description)
        {
            this.OrganizationId = organizationId;
            this.Name = name;
            this.Description = description;
        }
    }
}

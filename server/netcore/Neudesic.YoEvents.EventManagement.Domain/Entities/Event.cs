using Neudesic.YoEvents.EventManagement.Domain.Common;
using System;

namespace Neudesic.YoEvents.EventManagement.Domain.Entities
{
    public class Event : AuditableBaseEntity
    {
        public string Title { get; private set;  }
        public string Description { get; private set;  }
        
        private Event()
        { }

        public Event(Guid organizationId, string title, string description)
        {
            this.OrganizationId = organizationId;
            this.Title = title;
            this.Description = description;
        }
    }
}

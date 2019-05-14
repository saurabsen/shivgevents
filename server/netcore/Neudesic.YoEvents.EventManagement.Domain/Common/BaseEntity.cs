using System;

namespace Neudesic.YoEvents.EventManagement.Domain.Common
{
    /// <summary>
    /// Base entity for domain models that do NOT need auditability. 
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
    }
}

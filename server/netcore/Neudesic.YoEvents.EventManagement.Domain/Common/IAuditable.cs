using System;

namespace Neudesic.YoEvents.EventManagement.Domain.Common
{
    /// <summary>
    /// Implement this interface if the entity needs to have auditable fields
    /// </summary>
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}

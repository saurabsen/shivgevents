using System;

namespace Neudesic.YoEvents.EventManagement.Domain.Common
{
    /// <summary>
    /// Base entity for domain models, that need auditability
    /// </summary>
    public abstract class AuditableBaseEntity : BaseEntity, IAuditable
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Optional mechanism to set created/updated By
        /// Date fields are set at persistence time automagically
        /// </summary>
        /// <param name="createdBy"></param>
        /// <param name="updatedBy"></param>
        public void SetAuditFields(string createdBy, string updatedBy = null)
        {
            this.CreatedBy = createdBy;
            this.UpdatedBy = updatedBy;
        }
    }
}

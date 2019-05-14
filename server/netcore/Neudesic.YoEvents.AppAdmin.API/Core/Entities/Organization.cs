using System;

namespace Neudesic.YoEvents.AppAdmin.Core.Entities
{
    /// <summary>
    /// Entity for organization/tenant
    /// </summary>
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyUrl { get; set; }
        public string ContactEmail { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neudesic.YoEvents.AppAdmin.Core.Entities;

namespace Neudesic.YoEvents.EventManagement.Infrastructure.Data.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        /// <summary>
        /// Properties not specified are matched by default
        /// Only custom rules setup in this method
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(o => o.Name).IsRequired();
        }
    }
}

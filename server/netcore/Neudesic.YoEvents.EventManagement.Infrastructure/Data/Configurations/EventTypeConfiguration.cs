using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neudesic.YoEvents.EventManagement.Domain.Entities;
using System;

namespace Neudesic.YoEvents.EventManagement.Infrastructure.Data.Configurations
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        /// <summary>
        /// Properties not specified are matched by default
        /// Only custom rules setup in this method
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.Property(et => et.Name).IsRequired();
            builder.Property(et => et.Description).IsRequired();
        }
    }
}

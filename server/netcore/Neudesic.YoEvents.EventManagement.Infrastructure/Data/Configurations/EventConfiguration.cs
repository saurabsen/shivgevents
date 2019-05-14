using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neudesic.YoEvents.EventManagement.Domain.Entities;
using System;

namespace Neudesic.YoEvents.EventManagement.Infrastructure.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        /// <summary>
        /// Properties not specified are matched by default
        /// Only custom rules setup in this method
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title).IsRequired();
            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.CreatedDate).HasDefaultValue(DateTime.UtcNow).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedDate).HasDefaultValue(DateTime.UtcNow).ValueGeneratedOnUpdate();
        }
    }
}

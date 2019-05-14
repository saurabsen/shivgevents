using Microsoft.EntityFrameworkCore;
using Neudesic.YoEvents.EventManagement.Domain.Entities;
using Neudesic.YoEvents.EventManagement.Application.Interfaces;
using System.Threading.Tasks;

namespace Neudesic.YoEvents.EventManagement.Infrastructure
{
    public class EventManagementDbContext : DbContext, IEventManagementDbContext
    {
        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options)
           : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("eventmgmt");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventManagementDbContext).Assembly);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

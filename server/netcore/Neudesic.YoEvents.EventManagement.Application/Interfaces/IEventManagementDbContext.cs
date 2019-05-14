using Microsoft.EntityFrameworkCore;
using Neudesic.YoEvents.EventManagement.Domain.Entities;
using System.Threading.Tasks;

namespace Neudesic.YoEvents.EventManagement.Application.Interfaces
{
    public interface IEventManagementDbContext
    {
        DbSet<Event> Events { get; set; }
        DbSet<EventType> EventTypes { get; set; }

        Task<int> SaveChangesAsync();
    }
}
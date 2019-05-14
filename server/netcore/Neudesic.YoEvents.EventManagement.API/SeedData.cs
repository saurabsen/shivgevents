using Neudesic.YoEvents.EventManagement.Domain.Entities;
using Neudesic.YoEvents.EventManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.YoEvents.EventManagement.API
{
    public static class SeedData
    {
        public static void PopulateTestData(EventManagementDbContext dbContext)
        {
            var events = dbContext.Events;
            foreach (var item in events)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            var tenantId = Guid.NewGuid();
            dbContext.Events.AddRange(new Event(tenantId, "Event 1", "Desc for event 1"), new Event(tenantId, "Event 2", "Desc for event 2"));
            dbContext.SaveChanges();
        }
    }
}

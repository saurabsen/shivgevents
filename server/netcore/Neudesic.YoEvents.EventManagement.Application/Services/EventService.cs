using Neudesic.YoEvents.EventManagement.Application.Interfaces;
using Neudesic.YoEvents.EventManagement.Application.Models;
using Neudesic.YoEvents.EventManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Linq;

namespace Neudesic.YoEvents.EventManagement.Application.Services
{
    public class EventService : IEventService
    {
        readonly IEventManagementDbContext dbContext;
        readonly IMapper mapper;
        readonly IOrganizationAdapter organizationAdapter;

        public EventService(IEventManagementDbContext dbContext, IMapper mapper, IOrganizationAdapter organizationAdapter)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.organizationAdapter = organizationAdapter;
        }

        public async Task<Guid> CreateEvent(EventViewModel eventVm)
        {
            var orgs = await organizationAdapter.GetOrganizations();
            if (orgs.Count == 0)
                throw new Exception("No organizations setup.");

            var e = new Event(orgs.First().Id, eventVm.EventTitle, eventVm.Description);
            dbContext.Events.Add(e);
            await dbContext.SaveChangesAsync();

            return e.Id;
        }

        public async Task<List<EventViewModel>> GetAllEvents()
        {
            return await dbContext.Events.ProjectTo<EventViewModel>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<EventViewModel> GetEventDetails(Guid eventId)
        {
            var result = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);

            return mapper.Map<EventViewModel>(result);
        }
    }
}

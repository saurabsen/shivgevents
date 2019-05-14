using AutoMapper;
using Neudesic.YoEvents.EventManagement.Application.Mappings;
using Neudesic.YoEvents.EventManagement.Domain.Entities;
using System;

namespace Neudesic.YoEvents.EventManagement.Application.Models
{
    public class EventViewModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(eventDto => eventDto.EventTitle, opt => opt.MapFrom(e => e.Title))
                .ForMember(eventDto => eventDto.TenantId, opt => opt.MapFrom(e => e.OrganizationId));
        }
    }
}

using Neudesic.YoEvents.EventManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neudesic.YoEvents.EventManagement.Application.Interfaces
{
    public interface IEventService
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#tuples
        Task<Guid> CreateEvent(EventViewModel eventVm);

        Task<EventViewModel> GetEventDetails(Guid eventId);

        Task<List<EventViewModel>> GetAllEvents();
    }
}

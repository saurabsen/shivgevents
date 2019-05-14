using Neudesic.YoEvents.EventManagement.API;
using Neudesic.YoEvents.EventManagement.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Neudesic.YoEvents.EventManagement.IntegrationTests.Web
{
    public class EventsControllerTest : BaseFixture
    {
        public EventsControllerTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnsTwoItems()
        {
            HttpResponseMessage response = await client.GetAsync("/api/events");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Event>>(stringResponse).ToList();

            Assert.Equal(2, result.Count());
        }
    }
}

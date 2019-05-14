using Neudesic.YoEvents.EventManagement.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Neudesic.YoEvents.EventManagement.IntegrationTests.Web
{
    public class BaseFixture : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public readonly HttpClient client;

        public BaseFixture(CustomWebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
        }
    }
}

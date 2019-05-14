using Microsoft.Extensions.Configuration;
using Neudesic.YoEvents.EventManagement.Application.Interfaces;
using Neudesic.YoEvents.EventManagement.Application.Models;
using Neudesic.YoEvents.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neudesic.YoEvents.EventManagement.Adapters
{
    public class OrganizationAdapter : IOrganizationAdapter
    {
        private readonly HttpClient httpClient;
        readonly IConfiguration configuration;

        public OrganizationAdapter(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<OrganizationModel> GetOrganization(Guid orgId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrganizationModel>> GetOrganizations()
        {
            var uri = $"{configuration.GetValue<string>("AppSettings:OrgServiceBaseUrl")}/tenantmanagement";

            var response = await httpClient.GetAsync(uri);

            var organization = await HttpUtilities.GetResponseContent<List<OrganizationModel>>(response);

            return organization;
        }
    }
}

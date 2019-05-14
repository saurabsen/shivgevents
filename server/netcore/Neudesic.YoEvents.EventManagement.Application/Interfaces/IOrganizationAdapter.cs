using Neudesic.YoEvents.EventManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neudesic.YoEvents.EventManagement.Application.Interfaces
{
    public interface IOrganizationAdapter
    {
        Task<List<OrganizationModel>> GetOrganizations();

        Task<OrganizationModel> GetOrganization(Guid orgId);
    }
}

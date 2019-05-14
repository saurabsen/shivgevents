using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neudesic.YoEvents.AppAdmin.Core.Entities;
using Neudesic.YoEvents.AppAdmin.Infrastructure;

namespace Neudesic.YoEvents.AppAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantOnboardingController : ControllerBase
    {
        readonly IAppAdminDbContext appAdminDbContext;
        public TenantOnboardingController(IAppAdminDbContext appAdminDbContext)
        {
            this.appAdminDbContext = appAdminDbContext;
        }

        // GET: api/tenantonboarding/0E5E8F6E-3554-48B2-96FC-AEA573DE7E3D
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await appAdminDbContext.Organizations.FirstOrDefaultAsync(o => o.Id == id);
            return Ok(item);
        }

        // POST: api/tenantonboarding
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Organization organization)
        {
            var name = organization.Name.Trim().ToLowerInvariant();
            var existing = await appAdminDbContext.Organizations.AnyAsync(o => o.Name.Trim().ToLowerInvariant() == name);

            if (!existing)
            {
                appAdminDbContext.Organizations.Add(organization);
                await appAdminDbContext.SaveChangesAsync();
                return Created("api/tenant", new { id = organization.Id });
            }
            else
            {
                return BadRequest("Organization with same name already exists!!");
            }
        }
    }
}
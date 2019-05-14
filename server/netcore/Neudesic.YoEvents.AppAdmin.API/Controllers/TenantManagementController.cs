using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neudesic.YoEvents.AppAdmin.Infrastructure;

namespace Neudesic.YoEvents.AppAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantManagementController : ControllerBase
    {
        readonly IAppAdminDbContext appAdminDbContext;
        public TenantManagementController(IAppAdminDbContext appAdminDbContext)
        {
            this.appAdminDbContext = appAdminDbContext;
        }

        // GET: api/tenants
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tenants = await appAdminDbContext.Organizations.ToListAsync();
            return Ok(tenants);
        }
    }
}

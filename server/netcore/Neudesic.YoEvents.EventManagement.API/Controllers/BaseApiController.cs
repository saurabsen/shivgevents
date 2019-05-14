using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Neudesic.YoEvents.EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        //This will be retrieved from auth token
        public Guid OrganizationId { get; set; }

        public BaseApiController()
        {
            //OrganizationId = 
        }
    }
}
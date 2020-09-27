using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Services;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace OneSignalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneSignalController : ControllerBase
    {
        private readonly IOneSignalService _oneSignalService;

        public OneSignalController(IOneSignalService oneSignalService)
        {
            _oneSignalService = oneSignalService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
          => StatusCode((int)HttpStatusCode.OK, _oneSignalService.ViewAllApps());

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
            => StatusCode((int)HttpStatusCode.OK, _oneSignalService.ViewAppById(id));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] App app)
            => StatusCode((int)HttpStatusCode.Created, _oneSignalService.CreateApp(app));

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put([FromBody] App app)
            => StatusCode((int)HttpStatusCode.OK, _oneSignalService.UpdateApp(app));
    }
}
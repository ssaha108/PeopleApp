using Microsoft.AspNetCore.Mvc;
using People.API.Data;
using People.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace People.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IIntegrationService pds;
        public PeopleController(IIntegrationService integrationService)
        {
            pds = integrationService;
        }

        // GET api/people
        [HttpGet]
        public async Task<IActionResult> GetGenderCats()
        {
            try
            {
                var genderCats = await pds.GetGenderCats();
                return Ok(genderCats);
            }
            catch { return StatusCode(500,"API server says no!"); }
        }
    }
}

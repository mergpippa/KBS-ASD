using System;
using System.Collections.Generic;
using KBS.Infrastructure;
using KBS.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace KBS.Controller.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestEnvironmentController : ControllerBase
    {
        private readonly IManager _manager;

        public TestEnvironmentController(IManager manager) {
            _manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(404)]
        public List<TestEnvironment> GetTestEnvironments()
        {
            throw new NotImplementedException();
        }

        [HttpGet, Route("{id}")]
        [ProducesResponseType(404)]
        public TestEnvironment GetTestEnvironment(string name)
        {
            throw new NotImplementedException();
        }    

        [HttpPost]
        [ProducesResponseType(400)]
        public TestEnvironment CreateTestEnvironment([FromBody] TestConfiguration configuration)
        {
            /*if (!ModelState.IsValid)
                return BadRequest(ModelState);*/

            throw new NotImplementedException();
        }

    }
}

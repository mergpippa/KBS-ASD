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
            return _manager.GetTestEnvironments();
        }

        [HttpGet, Route("{id}")]
        [ProducesResponseType(404)]
        public TestEnvironment GetTestEnvironment(string name)
        {
            return _manager.GetTestEnvironment(name);
        }    

        [HttpPost]
        [ProducesResponseType(400)]
        public TestEnvironment CreateTestEnvironment([FromBody] TestConfiguration configuration)
        {
            /*if (!ModelState.IsValid)
                return BadRequest(ModelState);*/

            return _manager.CreateTestEnvironment(configuration);
        }

    }
}

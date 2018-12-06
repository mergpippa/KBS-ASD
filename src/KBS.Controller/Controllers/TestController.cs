using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Infrastructure;
using KBS.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace KBS.Controller.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IManager _manager;

        public TestController(IManager manager) {
            _manager = manager;
        }

        // GET api/test
        [HttpGet]
        [ProducesResponseType(404)]
        public async Task<List<TestEnvironment>> GetAllAsync() =>
            await _manager.GetTestEnvironmentsAsync();

        // Get api/test/{id}
        [HttpGet, Route("{id}")]
        [ProducesResponseType(404)]
        public async Task<TestEnvironment> GetTestAsync(string name) =>
            await _manager.GetTestEnvironmentAsync(name);

        // POST api/test
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<TestEnvironment> PostAsync([FromBody] TestConfiguration configuration)
        {
            /*if (!ModelState.IsValid)
                return BadRequest(ModelState);*/

            return await _manager.CreateTestEnvironmentAsync(configuration);
        }

    }
}

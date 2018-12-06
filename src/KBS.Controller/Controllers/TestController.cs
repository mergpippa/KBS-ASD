using KBS.Controller.Models;
using KBS.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KBS.Controller.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IManager _manager;

        public TestController(IManager manager)
        {
            _manager = manager;
        }

        // GET api/test
        [HttpGet]
        [ProducesResponseType(404)]
        public ActionResult GetAll()
        {
            return NotFound();
        }

        // POST api/test
        [HttpPost]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] TestConfiguration configuration)
        {
            return BadRequest();
        }
    }
}

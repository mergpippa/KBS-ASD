using System;
using System.Collections.Concurrent;
using KBS.Benchmark;
using KBS.TestCases.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace KBS.Controller.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET api/test
        [HttpGet]
        [ProducesResponseType(404)]
        public BlockingCollection<BenchmarkStateContext> GetAll()
        {
            throw new NotImplementedException();
        }

        // POST api/test
        [HttpPost]
        [ProducesResponseType(400)]
        public ActionResult<BenchmarkStateContext> Post([FromBody] TestCaseConfiguration configuration)
        {
            return new BenchmarkStateContext(configuration);
        }
    }
}

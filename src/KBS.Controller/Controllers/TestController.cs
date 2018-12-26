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
        private readonly ConcurrentBag<BenchmarkStateContext> benchmarks = new ConcurrentBag<BenchmarkStateContext>();

        // GET api/test
        [HttpGet]
        [ProducesResponseType(404)]
        public ConcurrentBag<BenchmarkStateContext> GetAll()
        {
            return benchmarks;
        }

        // POST api/test
        [HttpPost]
        [ProducesResponseType(400)]
        public ActionResult<BenchmarkStateContext> Post([FromBody] TestCaseConfiguration configuration)
        {
            var benchmark = new BenchmarkStateContext(configuration);
            
            benchmarks.Add(benchmark);
            
            return benchmark;
        }
    }
}

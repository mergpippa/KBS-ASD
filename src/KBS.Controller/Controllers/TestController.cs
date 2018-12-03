using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KBS.FauxApplication;
using KBS.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KBS.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
      
        private IManager _manager;

        public TestController(IManager manager){
            _manager = manager;
        }

        [HttpGet, Route("get")]
        public ActionResult<string> Get()
        {
            return _manager.GetState();
        }

        // POST api/values
        [HttpPost, Route("post")]
        public void Post([FromBody] Configuration configuration)
        {
            _manager.StartTest(configuration);
        }

    }
}

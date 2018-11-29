using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KBS.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KBS.Controller.Controllers
{
    [Route("api/testsuite")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
      
        private IManager _manager;

        public ValuesController(IManager manager){
            _manager = manager;
        }

        [HttpGet, Route("get")]
        public ActionResult<string> Get()
        {
            return _manager.GetResult();
        }

        // POST api/values
        [HttpPost, Route("post")]
        public void Post([FromBody] Configuration configuration)
        {
            _manager.StartTest(configuration);
        }

    }
}

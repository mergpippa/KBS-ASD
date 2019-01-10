using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.Controller.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KBS.Controller.Controllers
{
    [Route("api/benchmark")]
    [Produces("application/json")]
    [ApiController]
    public class BenchmarkController : ControllerBase
    {
        private static readonly HttpClient KuduHttpClient;

        static BenchmarkController()
        {
            KuduHttpClient = new HttpClient
            {
                BaseAddress = new Uri(ControllerConfiguration.KuduHost)
            };

            var byteArray = Encoding.ASCII.GetBytes(
                $"{ControllerConfiguration.KuduUsername}:{ControllerConfiguration.KuduPassword}"
            );

            KuduHttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        // GET api/test
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<string> GetWebJob()
        {
            var response = await KuduHttpClient.GetAsync(
                $"triggeredwebjobs/{ControllerConfiguration.WebJobName}"
            );

            return await response.Content.ReadAsStringAsync();
        }

        // GET api/test
        [HttpGet]
        [Route("history")]
        [ProducesResponseType(200)]
        public async Task<string> GetWebJobHistory()
        {
            var response = await KuduHttpClient.GetAsync(
                $"triggeredwebjobs/{ControllerConfiguration.WebJobName}/history"
            );

            return await response.Content.ReadAsStringAsync();
        }

        // POST api/test
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<string> TriggerWebjob([FromBody] SimpleBenchmarkConfiguration configuration)
        {
            var jsonConfiguration = JsonConvert.SerializeObject(configuration);

            var byteArray = Encoding.UTF8.GetBytes(jsonConfiguration);

            var response = await KuduHttpClient.PostAsync(
                $"triggeredwebjobs/{ControllerConfiguration.WebJobName}/run?arguments={Convert.ToBase64String(byteArray)}",
                null
            );

            return await response.Content.ReadAsStringAsync();
        }
    }
}

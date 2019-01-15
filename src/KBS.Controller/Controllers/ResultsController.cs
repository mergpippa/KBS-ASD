using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.Storage;
using KBS.Storage.Clients;
using Microsoft.AspNetCore.Mvc;

namespace KBS.Controller.Controllers
{
    [Route("api/results")]
    [Produces("application/json")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IStorageClient _storageClient = StorageClientFactory.Create(ControllerConfiguration.StorageClientType);

        /// <summary>
        /// Returns filenames that are saved in the Azure Storage Container
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<string>> GetAll() =>
            await _storageClient.GetAll();

        /// <summary>
        /// Redirects absolute file location on Azure Storage Container
        /// </summary>
        [HttpGet]
        [Route("{fileName}")]
        [ProducesResponseType(302)]
        public RedirectResult Get(string fileName) => new RedirectResult(
            $"https://{ControllerConfiguration.StorageAccountName}.blob.core.windows.net/{ControllerConfiguration.StorageAccountContainerName}/{fileName}"
        );

        /// <summary>
        /// Redirects absolute file location on Azure Storage Container
        /// </summary>
        [HttpDelete]
        [Route("{fileName}")]
        [ProducesResponseType(204)]
        public async Task Delete(string fileName) =>
            await _storageClient.Delete(fileName);
    }
}

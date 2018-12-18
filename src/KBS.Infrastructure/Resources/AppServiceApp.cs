using System;
using System.IO;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KBS.Infrastructure.Resources
{
    internal class AppServiceApp
    {
        private readonly string subscriptionId = "60b91b72-e8f0-412f-99af-7349fd751812";

        private readonly string clientId = "15785e10-cd50-4151-89d7-480266cdac81";

        private readonly string clientSecret = "oBexNPcDpVERex0uSFs0YLNMwMn3n3PNvQJTb9sUaAs=";

        private readonly string resourceGroupName = "AJTestCS";

        private readonly string deploymentName = "kbs-asd";

        private readonly string resourceGroupLocation = "West Europe";

        private readonly string pathToTemplateFile = "C:\\Users\\ArneJ\\source\\repos\\TestAzure\\TestAzure\\Template.json";

        private readonly string pathToParameterFile = "C:\\Users\\ArneJ\\source\\repos\\TestAzure\\TestAzure\\Parameters.json";

        private readonly string tenantId = "89b6e630-670d-4944-aecf-0056f43045e9";

        /// <summary>
        /// Starts a template deployment.
        /// </summary>
        public async void DeployTemplate()
        {
            // Trying to obtain the credentials
            var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret);

            // Read the template and parameter file contents
            JObject templateFileContents = GetJsonFileContents(pathToTemplateFile);
            JObject parameterFileContents = GetJsonFileContents(pathToParameterFile);

            // Create the resource manager client
            var resourceManagementClient = new ResourceManagementClient(serviceCreds);
            resourceManagementClient.SubscriptionId = subscriptionId;

            Console.WriteLine(string.Format("Starting template deployment '{0}' in resource group '{1}'", deploymentName, resourceGroupName));
            var deployment = new Deployment();

            deployment.Properties = new DeploymentProperties
            {
                Mode = DeploymentMode.Incremental,
                Template = templateFileContents,
                Parameters = parameterFileContents["parameters"].ToObject<JObject>()
            };

            Console.WriteLine(deployment.Properties.Parameters);
            try
            {
                var deploymentResult = resourceManagementClient.Deployments.CreateOrUpdate(resourceGroupName, deploymentName, deployment);
                Console.WriteLine(string.Format("Deployment status: {0}", deploymentResult.Properties.ProvisioningState));
            }
            catch (Exception e)
            {
                Console.WriteLine("bagger" + e);
            }
        }

        /// <summary>
        /// Reads a JSON file from the specified path
        /// </summary>
        /// <param name="pathToJson">
        /// The full path to the JSON file
        /// </param>
        /// <returns>
        /// The JSON file contents
        /// </returns>
        private JObject GetJsonFileContents(string pathToJson)
        {
            JObject templatefileContent = new JObject();
            using (StreamReader file = File.OpenText(pathToJson))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    templatefileContent = (JObject)JToken.ReadFrom(reader);
                    return templatefileContent;
                }
            }
        }
    }
}

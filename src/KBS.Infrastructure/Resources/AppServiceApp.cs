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
        private readonly string subscriptionId = Environment.GetEnvironmentVariable("subscription_id");

        private readonly string clientId = Environment.GetEnvironmentVariable("client_id");

        private readonly string clientSecret = Environment.GetEnvironmentVariable("client_secret");

        private readonly string resourceGroupName = Environment.GetEnvironmentVariable("resource_group_name");

        private readonly string tenantId = Environment.GetEnvironmentVariable("tenant_id");

        private readonly string deploymentName = Environment.GetEnvironmentVariable("deployment_name");

        private readonly string pathToTemplateFile = "C:\\Users\\ArneJ\\source\\repos\\TestAzure\\TestAzure\\Template.json";

        private readonly string pathToParameterFile = "C:\\Users\\ArneJ\\source\\repos\\TestAzure\\TestAzure\\Parameters.json";

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

using System;
using System.IO;
using KBS.Infrastructure.Models;
using KBS.Infrastructure.Resources;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KBS.Infrastructure.States
{
    class CreatingAppServiceAppState : ITestEnvironmentContextState
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

        public async void ProcessState(TestEnvironmentContext context, TestEnvironment testEnvironment)
        {
            // Trying to obtain the credentials
            var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret);

            // Read the template and parameter file contents
            JObject templateFileContents = GetJsonFileContents(pathToTemplateFile);
            JObject parameterFileContents = GetJsonFileContents(pathToParameterFile);

            // Create the resource manager client
            var resourceManagementClient = new ResourceManagementClient(serviceCreds);
            resourceManagementClient.SubscriptionId = subscriptionId;

            AppServiceApp.DeployTemplate(resourceManagementClient, resourceGroupName, deploymentName, templateFileContents, parameterFileContents);

            // TODO go to next step
        }

        /// <summary>
        /// Reads a JSON file from the specified path
        /// </summary>
        /// <param name="pathToJson">The full path to the JSON file</param>
        /// <returns>The JSON file contents</returns>
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

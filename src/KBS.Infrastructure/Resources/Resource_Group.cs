using System;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure.Authentication;

namespace KBS.Infrastructure.Resources
{
    internal class Resource_Group
    {
        private readonly string subscriptionId = "60b91b72-e8f0-412f-99af-7349fd751812";

        private readonly string clientId = "15785e10-cd50-4151-89d7-480266cdac81";

        private readonly string clientSecret = "oBexNPcDpVERex0uSFs0YLNMwMn3n3PNvQJTb9sUaAs=";

        private readonly string resourceGroupName = "AJTestCS";

        private readonly string tenantId = "89b6e630-670d-4944-aecf-0056f43045e9";

        private readonly string resourceGroupLocation = "West Europe";

        /// <summary>
        /// Ensures that a resource group with the specified name exists. If it does not, will
        /// attempt to create one.
        /// </summary>
        public async void EnsureResourceGroupExists()
        {
            // Trying to obtain the credentials
            var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret);

            // Create the resource manager client
            var resourceManagementClient = new ResourceManagementClient(serviceCreds);
            resourceManagementClient.SubscriptionId = subscriptionId;

            if (resourceManagementClient.ResourceGroups.CheckExistence(resourceGroupName) != true)
            {
                Console.WriteLine(string.Format("Creating resource group '{0}' in location '{1}'", resourceGroupName, resourceGroupLocation));
                var resourceGroup = new ResourceGroup();
                resourceGroup.Location = resourceGroupLocation;
                resourceManagementClient
                    .ResourceGroups
                    .CreateOrUpdate(resourceGroupName, resourceGroup);
            }
            else
            {
                Console.WriteLine(string.Format("Using existing resource group '{0}'", resourceGroupName));
            }
        }

        /// <summary>
        /// Deletes an existing resource group for a clean test environment
        /// </summary>
        public async void RemoveResourceGroup()
        {
            var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret);
            var resourceManagementClient = new ResourceManagementClient(serviceCreds);
            resourceManagementClient.SubscriptionId = subscriptionId;

            if (!resourceManagementClient.ResourceGroups.CheckExistence(resourceGroupName))
                Console.WriteLine(resourceGroupName + " does not exists");
            else
            {
                resourceManagementClient.ResourceGroups.Delete(resourceGroupName);
                Console.WriteLine(resourceGroupName + " deleted succesfully");
            }
        }
    }
}

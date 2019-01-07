using System;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure.Authentication;

namespace KBS.Infrastructure.Resources
{
    internal class Resource_Group
    {
        private readonly string subscriptionId = Environment.GetEnvironmentVariable("subscription_id");

        private readonly string clientId = Environment.GetEnvironmentVariable("client_id");

        private readonly string clientSecret = Environment.GetEnvironmentVariable("client_secret");

        private readonly string resourceGroupName = Environment.GetEnvironmentVariable("resource_group_name");

        private readonly string tenantId = Environment.GetEnvironmentVariable("tenant_id");

        private readonly string resourceGroupLocation = Environment.GetEnvironmentVariable("resource_group_location");

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

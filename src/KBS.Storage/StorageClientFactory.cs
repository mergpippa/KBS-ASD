using System;
using KBS.Data.Enum;
using KBS.Storage.Clients;

namespace KBS.Storage
{
    public static class StorageClientFactory
    {
        public static IStorageClient Create(StorageClientType storageClientType)
        {
            switch (storageClientType)
            {
                case StorageClientType.File:
                    return new FileStorageClient();

                case StorageClientType.AzureStorageContainer:
                    return new AzureStorageContainerStorageClient();

                default:
                    throw new ArgumentOutOfRangeException($"StorageClientType {storageClientType} does not exist");
            }
        }
    }
}

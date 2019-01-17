using KBS.Data.Enum;
using KBS.Storage;
using KBS.Storage.Clients;
using Xunit;

namespace KBS.StorageTests
{
    public class StorageClientFactoryTests
    {
        [Fact]
        public void Should_CreateFileStorageClient_When_StorageClientType_File()
        {
            var storageClient = StorageClientFactory.Create(StorageClientType.File);

            Assert.IsType<FileStorageClient>(storageClient);
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KBS.Exceptions;

namespace KBS.Storage.Clients
{
    public class FileStorageClient : IStorageClient
    {
        public Task Delete(string fileName) =>
            throw new NotImplementedByDesignException();

        /// <summary>
        /// FileStorageClient shouldn't implement the GetAll method because the FileStorageClient is
        /// only used for testing purposes
        /// </summary>
        public Task<List<string>> GetAll() =>
            throw new NotImplementedByDesignException();

        /// <summary>
        /// Writes the given text to a file
        /// </summary>
        /// <param name="text">
        /// </param>
        /// <param name="fileName">
        /// </param>
        /// <returns>
        /// </returns>
        public async Task WriteText(string text, string fileName)
        {
            await Task.Yield();

            File.WriteAllText($"./{fileName}", text);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace KBS.Storage.Clients
{
    public interface IStorageClient
    {
        Task WriteText(string text, string fileName);

        Task<List<string>> GetAll();
    }
}

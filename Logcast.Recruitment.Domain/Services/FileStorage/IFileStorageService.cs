#nullable enable
using System.Threading.Tasks;

namespace Logcast.Recruitment.Domain.Services.FileStorage
{
    public interface IFileStorageService
    {
        Task<string> Store(string filePath, byte[] content, string fileName, FileStorageBucket bucket);
        Task<byte[]?> Download(string filePath, string fileId, FileStorageBucket bucket);
    }
}
#nullable enable
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Domain.Services.FileStorage
{
    /// <summary>
    /// Stub file storage service for testing task to show MVP.
    /// In production you must use something like amazon S3 implementation.
    /// THIS WILL ONLY WORK FOR single instance application deployment.
    /// <see cref="FileStorageBucket.Temp"/> is meant to be configured in s3 settings 
    /// </summary>
    public class InMemoryFileStorageService : IFileStorageService
    {
        private readonly ConcurrentDictionary<string, byte[]?> _storage = new();

        public Task<string> Store(string filePath, byte[] content, string fileName, FileStorageBucket bucket)
        {
            var fileId = Guid.NewGuid().ToString();
            var key = GetKey(bucket, filePath, fileId);
            _storage[key] = content.ToArray();
            return Task.FromResult(fileId);
        }

        public Task<byte[]?> Download(string filePath, string fileId, FileStorageBucket bucket)
        {
            var key = GetKey(bucket, filePath, fileId);
            return Task.FromResult(_storage.GetValueOrDefault(key, null));
        }

        private string GetKey(FileStorageBucket bucket, string filePath, string fileId)
        {
            return $"{bucket}.{filePath}/{fileId}";
        }
    }
}
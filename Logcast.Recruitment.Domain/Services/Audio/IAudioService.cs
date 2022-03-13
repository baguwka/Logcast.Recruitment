#nullable enable
using System;
using System.IO;
using System.Threading.Tasks;
using Logcast.Recruitment.Shared.Models;

namespace Logcast.Recruitment.Domain.Services.Audio
{
    public interface IAudioService
    {
        Task<Guid> AddMetadata(AudioModel model);
        Task<AudioModel> GetMetadataById(Guid id);
        Task<FilePrimitive> StoreFile(byte[] bytes, string fileName);
        Task<Stream> GetAudioStream(Guid id);
    }
}
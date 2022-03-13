using System;
using System.IO;
using System.Threading.Tasks;
using Logcast.Recruitment.DataAccess.Exceptions;
using Logcast.Recruitment.DataAccess.Repositories;
using Logcast.Recruitment.Domain.Services.FileStorage;
using Logcast.Recruitment.Shared.Models;

namespace Logcast.Recruitment.Domain.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly IAudioRepository _audioRepository;
        private readonly IFileStorageService _fileStorageService;

        public AudioService(
            IAudioRepository audioRepository,
            IFileStorageService fileStorageService
        )
        {
            _audioRepository = audioRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<FilePrimitive> StoreFile(byte[] bytes, string fileName)
        {
            var fileId = await _fileStorageService.Store("audio-files", bytes, fileName, FileStorageBucket.Persistent);
            return new FilePrimitive
            {
                FileId = fileId,
                Name = fileName,
            }; 
        }

        public async Task<Stream> GetAudioStream(Guid id)
        {
            var audio = await _audioRepository.GetAudioById(id);
            var bytes = await _fileStorageService.Download("audio-files", audio.FileId, FileStorageBucket.Persistent);
            if (bytes is null)
            {
                throw new AudioNotFoundException();
            }
            
            return new MemoryStream(bytes);
        }

        public async Task<Guid> AddMetadata(AudioModel model)
        {
            return await _audioRepository.AddAudioFile(model);
        }

        public async Task<AudioModel> GetMetadataById(Guid id)
        {
            return await _audioRepository.GetAudioById(id);
        }
    }
}
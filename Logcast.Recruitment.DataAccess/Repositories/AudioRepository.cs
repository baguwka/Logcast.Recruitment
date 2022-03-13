using System;
using System.Threading.Tasks;
using Logcast.Recruitment.DataAccess.Entities;
using Logcast.Recruitment.DataAccess.Exceptions;
using Logcast.Recruitment.DataAccess.Factories;
using Logcast.Recruitment.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Logcast.Recruitment.DataAccess.Repositories
{
    public class AudioRepository : IAudioRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AudioRepository(IDbContextFactory dbContextFactory)
        {
            _applicationDbContext = dbContextFactory.Create();
        }

        public async Task<Guid> AddAudioFile(AudioModel audio)
        {
            var newAudio = await _applicationDbContext.Audios.AddAsync(new Audio(audio));
            await _applicationDbContext.SaveChangesAsync();

            return newAudio.Entity.Id;
        }

        public async Task<AudioModel> GetAudioById(Guid id)
        {
            var audio = await _applicationDbContext.Audios.FirstOrDefaultAsync(s => s.Id == id);
            if (audio is null)
            {
                throw new AudioNotFoundException();
            }
            return audio.ToDomainModel();
        }

        public async Task<AudioModel> GetAudioByFileId(string id)
        {
            var audio = await _applicationDbContext.Audios.FirstOrDefaultAsync(s => s.FileId == id);
            if (audio is null)
            {
                throw new AudioNotFoundException();
            }
            return audio.ToDomainModel();
        }
    }
}
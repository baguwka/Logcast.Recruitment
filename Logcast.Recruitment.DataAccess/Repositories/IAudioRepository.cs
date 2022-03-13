using System;
using System.Threading.Tasks;
using Logcast.Recruitment.Shared.Models;

namespace Logcast.Recruitment.DataAccess.Repositories
{
    public interface IAudioRepository
    {
        Task<Guid> AddAudioFile(AudioModel audio);
        Task<AudioModel> GetAudioById(Guid id);
        Task<AudioModel> GetAudioByFileId(string id);
    }
}
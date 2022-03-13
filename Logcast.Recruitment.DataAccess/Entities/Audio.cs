using System;
using System.ComponentModel.DataAnnotations;
using Logcast.Recruitment.Shared.Models;

namespace Logcast.Recruitment.DataAccess.Entities
{
    public class Audio
    {
        public Audio()
        {
            
        }
        
        public Audio(AudioModel audioModel)
        {
            FileId = audioModel.FileId;
            Name = audioModel.Name;
            Length = audioModel.Length;
            BitDepth = audioModel.BitDepth;
            Bitrate = audioModel.Bitrate;
            Channels = audioModel.Channels;
            DurationSeconds = audioModel.DurationSeconds;
            Artist = audioModel.Artist;
            Genre = audioModel.Genre;
        }

        [Required] public Guid Id { get; set; }
        [Required] public string FileId { get; set; }
        [Required] [MaxLength(200)] public string Name { get; set; }
        public int Length { get; set; }
        public int BitDepth { get; set; }
        public int Bitrate { get; set; }
        public int Channels { get; set; }
        public int DurationSeconds { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }

        public AudioModel ToDomainModel()
        {
            return new AudioModel
            {
                Id = Id,
                FileId = FileId,
                Name = Name,
                Length = Length,
                BitDepth = BitDepth,
                Bitrate = Bitrate,
                Channels = Channels,
                DurationSeconds = DurationSeconds,
                Artist = Artist,
                Genre = Genre
            };
        }
    }
}
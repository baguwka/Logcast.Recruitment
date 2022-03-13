using System;

namespace Logcast.Recruitment.Shared.Models
{
    public class AudioModel
    {
        public Guid Id { get; set; }
        public string FileId { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int BitDepth { get; set; }
        public int Bitrate { get; set; }
        public int Channels { get; set; }
        public int DurationSeconds { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
    }
}
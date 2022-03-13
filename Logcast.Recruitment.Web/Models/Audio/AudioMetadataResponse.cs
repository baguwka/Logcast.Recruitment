using System;
using Logcast.Recruitment.Shared.Models;

namespace Logcast.Recruitment.Web.Models.Audio
{
	public class AudioMetadataResponse
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
		public AudioMetadataResponse(AudioModel model)
		{
			Id = model.Id;
			FileId = model.FileId;
			Name = model.Name;
			Length = model.Length;
			BitDepth = model.BitDepth;
			Bitrate = model.Bitrate;
			Channels = model.Channels;
			DurationSeconds = model.DurationSeconds;
			Artist = model.Artist;
			Genre = model.Genre;
		}
	}
}

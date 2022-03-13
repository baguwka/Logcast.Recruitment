using Logcast.Recruitment.Shared.Models;

namespace Logcast.Recruitment.Web.Models.Audio
{
	public class AddAudioRequest
	{
		public string FileId { get; set; }
		public string Name { get; set; }
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

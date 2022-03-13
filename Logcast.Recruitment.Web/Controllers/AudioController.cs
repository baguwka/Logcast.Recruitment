#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Logcast.Recruitment.Domain.Services.Audio;
using Logcast.Recruitment.Shared.Models;
using Logcast.Recruitment.Web.Models.Audio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Logcast.Recruitment.Web.Controllers
{
    [ApiController]
    [Route("api/audio")]
    public class AudioController : ControllerBase
    {
	    private readonly IAudioService _audioService;

	    public AudioController(
		    IAudioService audioService
	        )
	    {
		    _audioService = audioService;
	    }

        [HttpPost("audio-files")]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio file uploaded successfully", typeof(UploadAudioFileResponse))]
        [ProducesResponseType(typeof(UploadAudioFileResponse), StatusCodes.Status200OK)]
        public async Task<FilePrimitive> UploadAudioFile(IFormFile audioFile)
        {
	        await using var str = new MemoryStream();
	        await audioFile.CopyToAsync(str);
	        var bytes = str.ToArray();
	        return await _audioService.StoreFile(bytes, audioFile.FileName);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio metadata registered successfully")]
        public async Task<AddMetadataResponse> AddAudioMetadata([Required] [FromBody] AddAudioRequest request)
        {
	        var id = await _audioService.AddMetadata(request.ToDomainModel());
	        return new AddMetadataResponse
	        {
		        Id = id
	        };
        }

        [HttpGet("{audioId:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio metadata fetched successfully", typeof(AudioMetadataResponse))]
        [ProducesResponseType(typeof(AudioMetadataResponse), StatusCodes.Status200OK)]
        public async Task<AudioMetadataResponse> GetAudioMetadata([FromRoute] Guid audioId)
        {
	        var metadata = await _audioService.GetMetadataById(audioId);
	        return new AudioMetadataResponse(metadata);
        }

        [HttpGet("{audioId:Guid}/stream")]
        [SwaggerResponse(StatusCodes.Status200OK, "Preview stream started successfully", typeof(FileContentResult))]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAudioStream([FromRoute] Guid audioId)
        {
	        var stream = await _audioService.GetAudioStream(audioId);
            return new FileStreamResult(stream, "audio/mpeg");
        }
	}
}
using ASPNet.API.Models.Domain;
using ASPNet.API.Models.DTOs;
using ASPNet.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPNet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    [HttpPost]
    [Route("Upload")]
    public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO requestDto )
    {
        ValidateFileUpload(requestDto);
        if (ModelState.IsValid)
        {
            //Converting DTO to DomainModel.
            var imageDomainModel = new Image
            {
                File = requestDto.File,
                FileExtension = Path.GetExtension(requestDto.File.FileName),
                FileSizeInBytes = requestDto.File.Length,
                FileName = requestDto.FileName,
                FileDescription = requestDto.FileDescription
            };

            await _imageRepository.Upload(imageDomainModel);

            return Ok(imageDomainModel);
        }

        return BadRequest(ModelState);
    }

    private void ValidateFileUpload(ImageUploadRequestDTO requestDto)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        if (allowedExtensions.Contains(Path.GetExtension(requestDto.File.FileName)) == false)
        {
            ModelState.AddModelError("file", "Unsupported File Extension.");
        }

        if (requestDto.File.Length > 10485760)
        {
            ModelState.AddModelError("file","File size more than 10MB. Please upload a smaller size file.");
        }
        
    }
}
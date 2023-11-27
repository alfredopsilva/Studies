using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNet.API.Models.Domain;

public class Image
{
    public Guid id { get; set; }
    //Not Mapped will prevent EF to create this field in our DB. 
    [NotMapped]
    public IFormFile File { get; set; }
    public string FileName { get; set; }
    public string? FileDescription { get; set; }
    public string FileExtension { get; set; }
    public long FileSizeInBytes { get; set; }
    public string FilePath { get; set; }
}
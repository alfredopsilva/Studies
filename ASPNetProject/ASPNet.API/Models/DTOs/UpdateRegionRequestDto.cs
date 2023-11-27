using System.ComponentModel.DataAnnotations;

namespace ASPNet.API.Models.DTOs;

public class UpdateRegionRequestDto
{
    [Required]
    [MinLength(3, ErrorMessage ="Code has to be a minimum of 3 characters.")]
    [MaxLength(3, ErrorMessage ="Code has to be a maximum of 3 characters.")]
    public string Code { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage ="Code has to be a maximum of 50 characters.")]
    public string Name { get; set; }
    
    public string? RegionImageUrl { get; set; } 
}
using System.ComponentModel.DataAnnotations;

namespace SpotifyMVC.DTOs.Request;

public class UpdateCategoryRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int ParentCategoryId { get; set; }
}
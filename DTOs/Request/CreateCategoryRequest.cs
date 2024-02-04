using System.ComponentModel.DataAnnotations;
using SpotifyMVC.Models;

namespace SpotifyMVC.DTOs.Request;

public class CreateCategoryRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int ParentCategoryId { get; set; }
}
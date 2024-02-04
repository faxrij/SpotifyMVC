using System.ComponentModel.DataAnnotations;

namespace SpotifyMVC.DTOs.Request;

public class CreateSingerRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
}
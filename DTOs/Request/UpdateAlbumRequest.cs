using System.ComponentModel.DataAnnotations;

namespace SpotifyMVC.DTOs.Request;

public class UpdateAlbumRequest
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int ReleaseYear { get; set; }
}
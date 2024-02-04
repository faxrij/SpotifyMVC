using System.ComponentModel.DataAnnotations;

namespace SpotifyMVC.DTOs.Request;

public class UpdateSongRequest
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int DurationInSeconds { get; set; }
    
    [Required]
    public String Lyrics { get; set; }
    
    [Required]
    public int AlbumId { get; set; }
}
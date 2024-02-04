using System.Text.Json.Serialization;

namespace SpotifyMVC.Models;

public class Album : Auditable
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    
    [JsonIgnore]
    public ICollection<Song> Songs { get; set; }
}
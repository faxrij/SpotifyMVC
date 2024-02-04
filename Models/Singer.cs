using System.Text.Json.Serialization;

namespace SpotifyMVC.Models;

public class Singer : Auditable
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    
    [JsonIgnore]
    public ICollection<Album> Albums { get; set; }
}
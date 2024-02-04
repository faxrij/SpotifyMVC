using System.Text.Json.Serialization;

namespace SpotifyMVC.Models;

public class Category : Auditable
{
    public string Name { get; set; }
    
    [JsonIgnore]
    public Category ParentCategory { get; set; }
    public Boolean isParentCategory { get; set; }
    
    [JsonIgnore]
    public ICollection<Song> Songs { get; set; }
}
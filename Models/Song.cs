using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpotifyMVC.Models;

public class Song
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
    public int SongId { get; set; }
    public string Title { get; set; }
    public int DurationInSeconds { get; set; }
    public String Lyrics { get; set; }
    
    [JsonIgnore]
    public ICollection<Category> Categories { get; set; }
    
    [JsonIgnore]
    public Album Album { get; set; }
}
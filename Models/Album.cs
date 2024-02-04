using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpotifyMVC.Models;

public class Album
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    
    [JsonIgnore]
    public ICollection<Song> Songs { get; set; }
}
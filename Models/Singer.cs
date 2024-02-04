using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpotifyMVC.Models;

public class Singer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
    public int SingerId { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    
    [JsonIgnore]
    public ICollection<Album> Albums { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpotifyMVC.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
    public int CategoryId { get; set; }
    public string Name { get; set; }
    
    [JsonIgnore]
    public Category ParentCategory { get; set; }
    public Boolean isParentCategory { get; set; }
    
    [JsonIgnore]
    public ICollection<Song> Songs { get; set; }
}
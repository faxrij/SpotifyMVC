using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpotifyMVC.Models;

public abstract class Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models;

public class Artist {
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
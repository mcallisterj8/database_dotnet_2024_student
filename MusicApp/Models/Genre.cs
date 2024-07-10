using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models;

public class Genre {
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
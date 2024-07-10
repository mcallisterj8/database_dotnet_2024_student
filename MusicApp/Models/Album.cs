using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models;

public class Album {
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [ForeignKey("Artist")]
    public int ArtistId { get; set; }
    public virtual Artist? Artist { get; set; }
    public DateTime ReleaseDate { get; set; }
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
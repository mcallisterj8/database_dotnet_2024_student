using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models;

public class Track {
    [Key]
    public int id { get; set; }
    [Required]
    public required string Title { get; set; }
    public int DurationInSeconds { get; set; }
    [ForeignKey("Album")]
    public int AlbumId { get; set; }
    public virtual Album? Album { get; set; }
    [ForeignKey("Genre")]
    public int GenreId { get; set; }
    public virtual Genre? Genre { get; set; }
    public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
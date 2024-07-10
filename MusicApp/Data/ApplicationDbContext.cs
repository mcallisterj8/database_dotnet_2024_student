using Microsoft.EntityFrameworkCore;
using MusicApp.Models;

namespace MusicApp.Data;

public class ApplicationDbContext : DbContext {
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Playlist> Playlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=music_app.db");
}

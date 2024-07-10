using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.Services;

public class SeedingService {
    private readonly ApplicationDbContext _context;
    private readonly Random _random = new Random();

    public SeedingService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task SeedDatabase() {
        await CreateArtists();
        await CreateGenres();
        await CreateAlbums();
        await CreateTracks();
        await CreatePlaylists();
    }

    private async Task CreateArtists() {
        var artists = new List<Artist> {
                new Artist { Name = "The Rolling Beats" },
                new Artist { Name = "Jazz Masters" },
                new Artist { Name = "Classical Ensemble" },
                new Artist { Name = "Pop Sensations" },
                new Artist { Name = "Electronic Vibes" }
            };

        await _context.Artists.AddRangeAsync(artists);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    private async Task CreateGenres() {
        var genres = new List<Genre> {
                new Genre { Name = "Rock" },
                new Genre { Name = "Pop" },
                new Genre { Name = "Jazz" },
                new Genre { Name = "Classical" },
                new Genre { Name = "Electronic" }
            };

        await _context.Genres.AddRangeAsync(genres);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    private async Task CreateAlbums() {
        var artists = await _context.Artists.ToListAsync();

        var albums = new List<Album> {
                new Album { Title = "Greatest Hits", ReleaseDate = DateTime.Now.AddYears(-10), Artist = artists[0] },
                new Album { Title = "Rock and Roll", ReleaseDate = DateTime.Now.AddYears(-8), Artist = artists[0] },
                new Album { Title = "Smooth Jazz", ReleaseDate = DateTime.Now.AddYears(-6), Artist = artists[1] },
                new Album { Title = "Jazz Nights", ReleaseDate = DateTime.Now.AddYears(-4), Artist = artists[1] },
                new Album { Title = "Symphony No. 1", ReleaseDate = DateTime.Now.AddYears(-15), Artist = artists[2] },
                new Album { Title = "Classical Moods", ReleaseDate = DateTime.Now.AddYears(-12), Artist = artists[2] },
                new Album { Title = "Pop Explosion", ReleaseDate = DateTime.Now.AddYears(-3), Artist = artists[3] },
                new Album { Title = "Pop Stars", ReleaseDate = DateTime.Now.AddYears(-1), Artist = artists[3] },
                new Album { Title = "Electro Beats", ReleaseDate = DateTime.Now.AddYears(-5), Artist = artists[4] },
                new Album { Title = "Electronic Symphony", ReleaseDate = DateTime.Now.AddYears(-2), Artist = artists[4] }
            };

        await _context.Albums.AddRangeAsync(albums);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    private async Task CreateTracks() {
        var albums = await _context.Albums.ToListAsync();
        var genres = await _context.Genres.ToListAsync();

        var tracks = new List<Track>();

        foreach (var album in albums) {
            for (int i = 1; i <= 10; i++) {
                var randomGenre = genres[_random.Next(genres.Count)];
                tracks.Add(new Track {
                    Title = $"{album.Title} Track {i}",
                    Duration = TimeSpan.FromMinutes(_random.Next(2, 6)),
                    Album = album,
                    Genre = randomGenre
                });
            }
        }

        await _context.Tracks.AddRangeAsync(tracks);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    private async Task CreatePlaylists() {
        var tracks = await _context.Tracks.ToListAsync();

        var playlists = new List<Playlist> {
                new Playlist { Name = "Morning Vibes" },
                new Playlist { Name = "Workout Mix" },
                new Playlist { Name = "Relaxing Tunes" },
                new Playlist { Name = "Study Session" },
                new Playlist { Name = "Party Hits" }
            };

        foreach (var playlist in playlists) {
            var trackCount = _random.Next(5, 15);
            var selectedTracks = tracks.OrderBy(t => Guid.NewGuid()).Take(trackCount).ToList();
            foreach (var track in selectedTracks) {
                playlist.Tracks.Add(track);
            }
        }

        await _context.Playlists.AddRangeAsync(playlists);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}

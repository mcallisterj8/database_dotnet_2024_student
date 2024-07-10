using MusicApp.Data;
using MusicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.Services;

public class LinqExamplesService {
    private readonly ApplicationDbContext _context;

    public LinqExamplesService(ApplicationDbContext context) {
        _context = context;
    }

    // Get all artists along with their albums.
    public async Task<List<Artist>> GetAllArtistsWithAlbums() {
        return await _context.Artists
            .Include(artist => artist.Albums)
            .ToListAsync();
    }

    // Get all albums along with their tracks.
    public async Task<List<Album>> GetAllAlbumsWithTracks() {
        return await _context.Albums
            .Include(album => album.Tracks)
            .ToListAsync();
    }

    // Find the first artist by name and include their albums.
    public async Task<Artist?> GetArtistByNameWithAlbums(string artistName) {
        return await _context.Artists
            .Include(artist => artist.Albums)
            .FirstOrDefaultAsync(artist => artist.Name == artistName);
    }

    // Get all tracks that belong to a specific album.
    public async Task<List<Track>> GetTracksByAlbumId(int albumId) {
        return await _context.Tracks
            .Where(track => track.AlbumId == albumId)
            .ToListAsync();
    }

    // Get all genres along with their tracks.
    public async Task<List<Genre>> GetAllGenresWithTracks() {
        return await _context.Genres
            .Include(genre => genre.Tracks)
            .ToListAsync();
    }

    // Get all tracks of a specific genre.
    public async Task<List<Track>> GetTracksByGenreId(int genreId) {
        return await _context.Tracks
            .Where(track => track.GenreId == genreId)
            .ToListAsync();
    }

    // Get the total number of tracks for each album.
    public async Task<List<object>> GetTotalTracksByAlbum() {
        var totalTracksByAlbum = await _context.Albums
            .Select(album => new {
                Album = album.Title,
                TotalTracks = album.Tracks.Count
            })
            .ToListAsync();

        return totalTracksByAlbum.Cast<object>().ToList();
    }

    // Get all albums released by a specific artist.
    public async Task<List<Album>> GetAlbumsByArtistId(int artistId) {
        return await _context.Albums
            .Where(album => album.ArtistId == artistId)
            .ToListAsync();
    }

    // Get all playlists along with their tracks.
    public async Task<List<Playlist>> GetAllPlaylistsWithTracks() {
        return await _context.Playlists
            .Include(playlist => playlist.Tracks)
            .ToListAsync();
    }

    // Get the most recent album by each artist.
    // public async Task<List<object>> GetMostRecentAlbumByArtist() {
    //     var recentAlbumsByArtist = await _context.Artists
    //         .Select(artist => new {
    //             Artist = artist.Name,
    //             RecentAlbum = artist.Albums.OrderByDescending(album => album.ReleaseDate).FirstOrDefault()
    //         })
    //         .ToListAsync();

    //     return recentAlbumsByArtist.Cast<object>().ToList();
    // }

    /*
        Below is an alternative approach to the aboce commented out method.
        The below method gives a list of albums rather than a list of objects.
    */
    // Get the most recent album by each artist.
    public async Task<List<Album?>> GetMostRecentAlbumByArtist() {
        return await _context.Artists
            .Select(artist => artist.Albums
                .OrderByDescending(album => album.ReleaseDate)
                .FirstOrDefault())
            .Where(album => album != null) // Filter out any null albums
            .ToListAsync();
    }

    // Get the average duration of tracks for each genre.
    public async Task<List<object>> GetAverageDurationByGenre() {
        var averageDurationByGenre = await _context.Genres
            .Select(genre => new {
                Genre = genre.Name,
                AverageDuration = genre.Tracks.Average(track => track.DurationInSeconds)
            })
            .ToListAsync();

        return averageDurationByGenre.Cast<object>().ToList();
    }

    // Get all artists who have not released any albums.
    public async Task<List<Artist>> GetArtistsWithoutAlbums() {
        return await _context.Artists
            .Where(artist => 0 == artist.Albums.Count)
            .ToListAsync();
    }

    // Get all tracks along with their genre and album information.
    public async Task<List<Track>> GetTracksWithGenreAndAlbum() {
        return await _context.Tracks
            .Include(track => track.Genre)
            .Include(track => track.Album)
            .ToListAsync();
    }

    // Get the names of all tracks along with their album title and artist name.
    public async Task<List<object>> GetTrackDetails() {
        var trackDetails = await _context.Tracks
            .Select(t => new {
                TrackName = t.Title,
                AlbumTitle = t.Album.Title,
                ArtistName = t.Album.Artist.Name
            })
            .ToListAsync();

        return trackDetails.Cast<object>().ToList();
    }

    // Get all albums along with the total duration of their tracks.
    public async Task<List<object>> GetAlbumsWithTrackDuration() {
        var albumsWithTrackDuration = await _context.Albums
            .Select(album => new {
                AlbumTitle = album.Title,
                TotalDuration = album.Tracks.Sum(t => t.DurationInSeconds)
            })
            .ToListAsync();

        return albumsWithTrackDuration.Cast<object>().ToList();
    }

    // Get all genres along with the number of tracks in each genre.
    public async Task<List<object>> GetGenreTrackCounts() {
        var genreTrackCounts = await _context.Genres
            .Select(genre => new {
                GenreName = genre.Name,
                TrackCount = genre.Tracks.Count
            })
            .ToListAsync();

        return genreTrackCounts.Cast<object>().ToList();
    }

    // Get all playlists along with the total number of tracks in each playlist.
    public async Task<List<object>> GetPlaylistsWithTrackCount() {
        var playlistsWithTrackCount = await _context.Playlists
            .Select(playlist => new {
                PlaylistName = playlist.Name,
                TrackCount = playlist.Tracks.Count()
            })
            .ToListAsync();

        return playlistsWithTrackCount.Cast<object>().ToList();
    }

    // Get all tracks for a specific playlist.
    public async Task<List<Track>> GetTracksByPlaylistId(int playlistId) {
        return await _context.Playlists
            .Where(playlist => playlist.Id == playlistId)
            .SelectMany(playlist => playlist.Tracks)
            .ToListAsync();
    }

    // Get the playlist with the most tracks.
    public async Task<Playlist?> GetPlaylistWithMostTracks() {
        return await _context.Playlists
            .OrderByDescending(playlist => playlist.Tracks.Count)
            .FirstOrDefaultAsync();
    }

    // Get the playlist with the least tracks.
    public async Task<Playlist?> GetPlaylistWithLeastTracks() {
        return await _context.Playlists
            .OrderBy(playlist => playlist.Tracks.Count)
            .FirstOrDefaultAsync();
    }

    // Get the top 3 playlists with the most tracks.
    public async Task<List<Playlist>> GetTopThreePlaylistsWithMostTracks() {
        return await _context.Playlists
            .OrderByDescending(playlist => playlist.Tracks.Count)
            .Take(3)
            .ToListAsync();
    }

    // Get the top 3 playlists with the least tracks.
    public async Task<List<Playlist>> GetTopThreePlaylistsWithLeastTracks() {
        return await _context.Playlists
            .OrderBy(playlist => playlist.Tracks.Count)
            .Take(3)
            .ToListAsync();
    }

    // Get the names and track counts of the top 5 playlists with the most tracks.
    public async Task<List<object>> GetTopFivePlaylistsWithMostTracks() {
        var result = await _context.Playlists
            .OrderByDescending(playlist => playlist.Tracks.Count)
            .Select(playlist => new {
                PlaylistName = playlist.Name,
                TrackCount = playlist.Tracks.Count
            })
            .Take(5)
            .ToListAsync();

        return result.Cast<object>().ToList();
    }

    // Get the names and track counts of the bottom 5 playlists with the least tracks.
    public async Task<List<object>> GetBottomFivePlaylistsWithLeastTracks() {
        var result = await _context.Playlists
            .OrderBy(playlist => playlist.Tracks.Count)
            .Select(playlist => new {
                PlaylistName = playlist.Name,
                TrackCount = playlist.Tracks.Count
            })
            .Take(5)
            .ToListAsync();

        return result.Cast<object>().ToList();
    }
}

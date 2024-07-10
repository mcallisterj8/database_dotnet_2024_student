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
        return null;
    }

    // Find the first artist by name and include their albums.
    public async Task<Artist?> GetArtistByNameWithAlbums(string artistName) {
        return null;
    }

    // Get all tracks that belong to a specific album.
    public async Task<List<Track>> GetTracksByAlbumId(int albumId) {
        return null;
    }

    // Get all genres along with their tracks.
    public async Task<List<Genre>> GetAllGenresWithTracks() {
        return null;
    }

    // Get all tracks of a specific genre.
    public async Task<List<Track>> GetTracksByGenreId(int genreId) {
        return null;
    }

    // Get the total number of tracks for each album.
    public async Task<List<object>> GetTotalTracksByAlbum() {
        return null;
    }

    // Get all albums released by a specific artist.
    public async Task<List<Album>> GetAlbumsByArtistId(int artistId) {
        return null;
    }

    // Get all playlists along with their tracks.
    public async Task<List<Playlist>> GetAllPlaylistsWithTracks() {
        return null;
    }

    // Get the most recent album by each artist.
    public async Task<List<object>> GetMostRecentAlbumByArtist() {
        var recentAlbumsByArtist = await _context.Artists
            .Select(artist => new {
                Artist = artist.Name,
                RecentAlbum = artist.Albums
                                .OrderByDescending(album => album.ReleaseDate)
                                .FirstOrDefault()
            }).ToListAsync();

            return recentAlbumsByArtist.Cast<object>().ToList();
            
    }

    // Get the average duration of tracks for each genre.
    public async Task<List<object>> GetAverageDurationByGenre() {
        return null;
    }

    // Get all artists who have not released any albums.
    public async Task<List<Artist>> GetArtistsWithoutAlbums() {
        return null;
    }

    // Get all tracks along with their genre and album information.
    public async Task<List<Track>> GetTracksWithGenreAndAlbum() {
        return null;
    }

    // Get the names of all tracks along with their album title and artist name.
    public async Task<List<object>> GetTrackDetails() {
        var trackDetails = await _context.Tracks
            .Select(track => new {
                TrackName = track.Title,
                AlbumTitle = track.Album.Title,
                ArtistName = track.Album.Artist.Name
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
            .Select(g => new {
                GenreName = g.Name,
                TrackCount = g.Tracks.Count
            })
            .ToListAsync();

            return genreTrackCounts.Cast<object>().ToList();
    }

    // Get all playlists along with the total number of tracks in each playlist.
    public async Task<List<object>> GetPlaylistsWithTrackCount() {
        return null;
    }

    // Get all tracks for a specific playlist.
    public async Task<List<Track>> GetTracksByPlaylistId(int playlistId) {
        return null;
    }

    // Get the playlist with the most tracks.
    public async Task<Playlist?> GetPlaylistWithMostTracks() {
        return null;
    }

    // Get the playlist with the least tracks.
    public async Task<Playlist?> GetPlaylistWithLeastTracks() {
        return null;
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
        return null;
    }

    // Get the names and track counts of the top 5 playlists with the most tracks.
    public async Task<List<object>> GetTopFivePlaylistsWithMostTracks() {
        return null;
    }

    // Get the names and track counts of the bottom 5 playlists with the least tracks.
    public async Task<List<object>> GetBottomFivePlaylistsWithLeastTracks() {
        return null;
    }
}

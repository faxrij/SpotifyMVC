// SongService.cs

using Microsoft.EntityFrameworkCore;
using SpotifyMVC.Data;
using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Interfaces;
using SpotifyMVC.Models;

namespace SpotifyMVC.Services;

public class SongService : ISongService
{
    private readonly DataContext _context;

    public SongService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Song>> GetAllSongsAsync()
    {
        return await _context.Songs.ToListAsync();
    }

    public async Task<Song?> GetSongByIdAsync(int id)
    {
        return await _context.Songs
            .Include(s => s.Categories)
            .Include(s => s.Album)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Song> CreateSongAsync(CreateSongRequest createSongRequest)
    {
        Song song = new Song();
        Album? album = await _context.Albums.Where(a => a.Id == createSongRequest.AlbumId).FirstOrDefaultAsync();

        if (album == null)
        {
            throw new InvalidOperationException($"Album with ID {createSongRequest.AlbumId} not found.");
        }
        
        song.Album = album;
        song.Lyrics = createSongRequest.Lyrics;
        song.Title = createSongRequest.Title;
        song.DurationInSeconds = createSongRequest.DurationInSeconds;
        song.Categories = new List<Category>();
        _context.Songs.Add(song);
        await _context.SaveChangesAsync();
        return song;
    }

    public async Task<bool> RemoveSongAsync(int id)
    {
        var songToRemove = await _context.Songs.FindAsync(id);

        if (songToRemove == null)
        {
            return false;
        }

        _context.Songs.Remove(songToRemove);
        await _context.SaveChangesAsync();
        return true;
    }
}
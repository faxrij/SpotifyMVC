using Microsoft.EntityFrameworkCore;
using SpotifyMVC.Data;
using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Interfaces;
using SpotifyMVC.Models;

namespace SpotifyMVC.Services;

public class AlbumService : IAlbumService
{
    private readonly DataContext _context;

    public AlbumService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Album>> GetAllAlbumsAsync()
    {
        return await _context.Albums.ToListAsync();
    }

    public async Task<Album?> GetAlbumByIdAsync(int id)
    {
        return await _context.Albums
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Album> CreateAlbumAsync(CreateAlbumRequest createAlbumRequest)
    {
        Album album = new Album();
        album.Songs = new List<Song>();
        album.ReleaseYear = createAlbumRequest.ReleaseYear;
        album.Title = createAlbumRequest.Title;
        album.CreatedAt = DateTime.UtcNow;
        album.ModifiedAt = DateTime.UtcNow;
        _context.Albums.Add(album);
        await _context.SaveChangesAsync();
        return album;
    }

    public async Task<bool> RemoveAlbumAsync(int id)
    {
        var albumToRemove = await _context.Albums.FindAsync(id);

        if (albumToRemove == null)
        {
            return false;
        }

        _context.Albums.Remove(albumToRemove);
        await _context.SaveChangesAsync();
        return true;
    }
}

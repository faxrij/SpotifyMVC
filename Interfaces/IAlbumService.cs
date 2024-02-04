using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Models;

namespace SpotifyMVC.Interfaces;

public interface IAlbumService
{
    Task<List<Album>> GetAllAlbumsAsync();
    Task<Album?> GetAlbumByIdAsync(int id);
    Task<Album> CreateAlbumAsync(CreateAlbumRequest createAlbumRequest);
    Task<bool> RemoveAlbumAsync(int id);
}

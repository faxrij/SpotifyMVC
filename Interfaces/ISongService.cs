using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Models;

namespace SpotifyMVC.Interfaces;

public interface ISongService
{
    Task<List<Song>> GetAllSongsAsync();
    Task<Song?> GetSongByIdAsync(int id);
    Task<Song> CreateSongAsync(CreateSongRequest createSongRequest);
    Task<bool> RemoveSongAsync(int id);
    Task<Song?> UpdateSongAsync(UpdateSongRequest updateSongRequest, int id);
}

using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Models;

namespace SpotifyMVC.Interfaces;

public interface ISingerService
{
    Task<List<Singer>> GetAllSingersAsync();
    Task<Singer?> GetSingerByIdAsync(int id);
    Task<Singer> CreateSingerAsync(CreateSingerRequest createSingerRequest);
    Task<bool> RemoveSingerAsync(int id);
    Task<Singer?> UpdateSingerAsync(UpdateSingerRequest updateSingerRequest, int id);
}

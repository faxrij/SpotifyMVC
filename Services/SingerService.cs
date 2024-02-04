using Microsoft.EntityFrameworkCore;
using SpotifyMVC.Data;
using SpotifyMVC.DTOs.Request;
using SpotifyMVC.Interfaces;
using SpotifyMVC.Models;

namespace SpotifyMVC.Services;

public class SingerService : ISingerService
{
    private readonly DataContext _context;

    public SingerService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Singer>> GetAllSingersAsync()
    {
        return await _context.Singers.ToListAsync();
    }

    public async Task<Singer?> GetSingerByIdAsync(int id)
    {
        return await _context.Singers
            .Include(s => s.Albums) 
            .FirstOrDefaultAsync(s => s.SingerId == id);
    }

    public async Task<Singer> CreateSingerAsync(CreateSingerRequest createSingerRequest)
    {
        Singer singer = new Singer();
        singer.Albums = new List<Album>();
        singer.Name = createSingerRequest.Name;
        singer.BirthDate = createSingerRequest.BirthDate;
        _context.Singers.Add(singer);
        await _context.SaveChangesAsync();
        return singer;
    }

    public async Task<bool> RemoveSingerAsync(int id)
    {
        var singerToRemove = await _context.Singers.FindAsync(id);

        if (singerToRemove == null)
        {
            return false;
        }

        _context.Singers.Remove(singerToRemove);
        await _context.SaveChangesAsync();
        return true;
    }
}
